using UnityEngine;

public enum StudentStates { RestAndSleep = 0, StudyHard, TakeAExam, PlayAGame, HitTheBottle }

public class Student : BaseGameEntity
{
    private int knowledge;          // 지식
    private int stress;             // 스트레스
    private int fatigue;            // 피로
    private int totalScore;         // 점수
    private Locations currentLocation;  // 현재 위치

    // Student가 가지고 있는 모든 상태, 현재 상태
    // private State[] states;
    // private State currentState;

    public int Knowledge
    {
        set => knowledge = Mathf.Max(0, value);
        get => knowledge;
    }
    public int Stress
    {
        set => stress = Mathf.Max(0, value);
        get => stress;
    }
    public int Fatigue
    {
        set => fatigue = Mathf.Max(0, value);
        get => fatigue;
    }
    public int TotalScore
    {
        set => totalScore = Mathf.Clamp(value, 0, 100);
        get => totalScore;
    }
    public Locations CurrentLocation
    {
        set => currentLocation = value;
        get => currentLocation;
    }

    public override void Setup(string name)
    {
        // 기반 클래스의 Setup 메소드 호출 (ID, 이름, 색상 설정)
        base.Setup(name);

        // 생성되는 오브젝트의 이름 설정
        gameObject.name = $"{ID:D2}_Student_{name}";

        knowledge = 0;
        stress = 0;
        fatigue = 0;
        totalScore = 0;
        currentLocation = Locations.SweetHome;

        PrintText("Hello Real World");
    }

    public override void Updated()
    {
        PrintText("대기중입니다...");
    }

}
