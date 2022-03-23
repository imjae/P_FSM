using System.Data.SqlTypes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMScript : MonoBehaviour
{
    public enum State { Idle, Fly, Attack };
    public State state;

    public SpriteRenderer SR;
    public Animator AN;
    public List<Sprite> AllSprites;
    WaitForSeconds Delay01 = new WaitForSeconds(0.1f);
    WaitForSeconds Delay05 = new WaitForSeconds(0.5f);
    WaitForSeconds Delay1 = new WaitForSeconds(1f);
    List<Sprite> CurSprites;
    int characterIndex;
    readonly int SIZE = 4;

    public void SetCharacter(int index)
    {
        characterIndex = index;
        CurSprites.Clear();
        for (int i = 0; i < SIZE; i++) CurSprites.Add(AllSprites[SIZE * characterIndex + i]);
    }

    void Awake()
    {
        CurSprites = new List<Sprite>();
    }

    IEnumerator Start()
    {
        SetCharacter(0);
        while (true) yield return StartCoroutine(state.ToString());
    }

    IEnumerator Idle()
    {
        SR.sprite = CurSprites[0];
        yield return Delay05;
        SR.sprite = CurSprites[1];
        yield return Delay05;
    }
    IEnumerator Fly()
    {
        SR.sprite = CurSprites[2];
        yield return Delay01;
        SR.sprite = CurSprites[3];
        yield return Delay01;
    }

    IEnumerator Attack()
    {
        SR.sprite = CurSprites[0];
        AN.SetTrigger("attack");
        yield return Delay1;
        state = State.Idle;
    }
}
