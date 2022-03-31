using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Locations { SweetHome = 0, Library, LectureRoom, PCRoom, Pub };

public class GameController : MonoBehaviour
{
    [SerializeField] private string[] arrayStudents;
    [SerializeField] private GameObject studentPrefab;
    [SerializeField] private string[] arrayUnemployeds;
    [SerializeField] private GameObject unemployedPrefab;


    // 재생 제어를 위한 모든 에이전트 리스트
    private List<BaseGameEntity> entityList;

    public static bool IsGameStop { set; get; } = false;

    private void Awake()
    {
        entityList = new List<BaseGameEntity>();

        for (int i = 0; i < arrayStudents.Length; i++)
        {
            // 에이전트 생성, 초기화 메소드 호출
            GameObject clone = Instantiate(studentPrefab);
            Student entity = clone.GetComponent<Student>();
            entity.Setup(arrayStudents[i]);

            // 에이전트들의 재생 제어를 위해 리스트에 저장
            entityList.Add(entity);
        }

        for (int i = 0; i < arrayStudents.Length; i++)
        {
            // 에이전트 생성, 초기화 메소드 호출
            GameObject clone = Instantiate(unemployedPrefab);
            Unemployed entity = clone.GetComponent<Unemployed>();
            entity.Setup(arrayUnemployeds[i]);

            // 에이전트들의 재생 제어를 위해 리스트에 저장
            entityList.Add(entity);
        }
    }

    private void Update()
    {
        if (IsGameStop == true) return;
        // 모든 에이전트의 Updated()를 호출해 에이전트 구동
        for (int i = 0; i < entityList.Count; i++)
        {
            entityList[i].Updated();
        }
    }

    public static void Stop(BaseGameEntity entity)
    {
        IsGameStop = true;

        entity.PrintText("100점 획득으로 프로그램 종료합니다.");
    }
}
