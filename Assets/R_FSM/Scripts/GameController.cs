using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Locations { SweetHome = 0, Library, LectureRoom, PCRoom, Pub };

public class GameController : MonoBehaviour
{
    [SerializeField]
    private string[] arrayStudents;
    [SerializeField]
    private GameObject studentPrefab;

    // 재생 제어를 위한 모든 에이전트 리스트
    private List<BaseGameEntity> entityList;

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
    }

    private void Update()
    {
        // 모든 에이전트의 Updated()를 호출해 에이전트 구동
        for (int i = 0; i < entityList.Count; i++)
        {
            entityList[i].Updated();
        }
    }
}
