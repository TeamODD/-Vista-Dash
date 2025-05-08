using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlatformSpawner Spawner; //PlatformSpawner 를 Spawner로 불러옴
    public ScrollingObject ScrollingObject;

    public int CurrentStage = 1; //현재 스테이지값 = 1

    public float Stage2Multiple = 1.2f; 
    public float Stage3Multiple = 1.5f;

    public float CurrentSpeed = 10.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Spawner = FindAnyObjectByType<PlatformSpawner>();
        Spawner.UpdatePlatformSpeed(CurrentSpeed); // PlatformSpawner의 Speed를 현재 속도로 변경
    }

    // Update is called once per frame
    void Update()
    {
        int CurrentScore = Spawner.GetScore(); // PlatformSpawner에서 현재 스코어 받아옴

        if (CurrentStage == 1 && CurrentScore >= 10) // 2스테이지 진입시
        {
            CurrentStage = 2; 
            CurrentSpeed = CurrentSpeed * Stage2Multiple; // 1.2배 == 12f
            Spawner.UpdatePlatformSpeed(CurrentSpeed); // 스포너
            ScrollingObject.UpdateSpeed(CurrentSpeed); // 스크롤링 둘다 속도 변경
        }
        else if (CurrentStage == 2 && CurrentScore >= 20) // 3스테이지 진입시
        {
            CurrentStage = 3;
            CurrentSpeed = CurrentSpeed * Stage3Multiple; // 1.5배 == 18f
            Spawner.UpdatePlatformSpeed(CurrentSpeed);
            ScrollingObject.UpdateSpeed(CurrentSpeed);
        }
    }
}
