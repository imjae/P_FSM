using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnemployedStates { RestAndSleep = 0, PlayAGame, HitTheBottle, VisitBathroom, Global }

public class Unemployed : BaseGameEntity
{
    private int bored;                 // 지루함
    private int stress;                 // 스트레스
    private int fatigue;                // 피로
    private Locations currentLocation;  // 현재 위치

    // Unemployed가 가지고 있는 모든 상태, 상태 관리자
    private State<Unemployed>[] states;
    private StateMachine<Unemployed> stateMachine;

    public int Bored
    {
        get => bored;
        set => bored = Mathf.Max(0, value);
    }
    public int Stress
    {
        get => stress;
        set => stress = Mathf.Max(0, value);
    }
    public int Fatigue
    {
        get => fatigue;
        set => fatigue = Mathf.Max(0, value);
    }
    public Locations CurrentLocation
    {
        get => currentLocation;
        set => currentLocation = value;
    }

    public UnemployedStates CurrentState { private set; get; }

    public override void Setup(string name)
    {
        base.Setup(name);

        // 생성되는 오브젝트 이름 설정
        gameObject.name = $"{ID:D2}_Unemployed_{name}";

        // Unemployed가 가질 수 있는 상태 개수만큼 메모리 할당, 각 상태에 클래스 메모리 할당
        states = new State<Unemployed>[5];
        states[(int)UnemployedStates.RestAndSleep] = new UnemployedOwnedStates.RestAndSleep();
        states[(int)UnemployedStates.PlayAGame] = new UnemployedOwnedStates.PlayAGame();
        states[(int)UnemployedStates.HitTheBottle] = new UnemployedOwnedStates.HitTheBottle();
        states[(int)UnemployedStates.VisitBathroom] = new UnemployedOwnedStates.VisitBathroom();
        states[(int)UnemployedStates.Global] = new UnemployedOwnedStates.StateGlobal();

        // 상태를 관리하는 StateMachnie에 메모리를 할당하고, 첫 상태를 설정
        stateMachine = new StateMachine<Unemployed>();
        stateMachine.Setup(this, states[(int)UnemployedStates.RestAndSleep]);
        // 전역상태 설정
        stateMachine.SetGlobalState(states[(int)UnemployedStates.Global]);

        bored = 0;
        stress = 0;
        fatigue = 0;
        currentLocation = Locations.SweetHome;
    }

    public override void Updated()
    {
        stateMachine.Execute();
    }

    public void ChangeState(UnemployedStates newState)
    {
        CurrentState = newState;

        stateMachine.ChangeState(states[(int)newState]);
    }

    public void RevertToPreviousState()
    {
        stateMachine.RevertToPreviousState();
    }
}
