using System.Data.SqlTypes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMScript : MonoBehaviour
{
    public enum State { Idle, Fly };
    public State state;

    public SpriteRenderer SR;
    public List<Sprite> AllSprites;
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
        Debug.Log("IDLE");
        yield return new WaitForSeconds(1f);
    }
    IEnumerator Fly()
    {
        Debug.Log("Fly");
        yield return new WaitForSeconds(1f);
    }
}
