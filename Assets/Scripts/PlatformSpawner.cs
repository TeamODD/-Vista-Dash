using System.Threading;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public int Score = 0; //스코어 초기값 0

    public GameObject PlatformPrefeb;
    public ItemSpawner ItemSpawner;
    public GameManager gameManager;

    public float CurrentSpeed;
    int CurrentStage; // 게임 매니저에서 가져올 스테이지 정보를 저장
    float MaxYpos; // 현재 스포너의 최대 y축 높이 
    float MinYpos; // 현재 스포너의 최소 y축 높이 ->
    // 최소에서 최대 사이, 즉 직사각형 형태의 스포너 객체의 높이에서 플랫폼을 지속 생성
    // 스테이지 마다 다른 디자인을 가진 플랫폼 프리팹 두 개 ( 4칸, 5칸 )
    [SerializeField] GameObject platform1_1;
    [SerializeField] GameObject platform1_2;
    [SerializeField] GameObject platform2_1;
    [SerializeField] GameObject platform2_2;
    [SerializeField] GameObject platform3_1;
    [SerializeField] GameObject platform3_2;
    // 스폰 시간 조정 관련
    [SerializeField] float SpawnDuration; // 초마다 플랫폼 생성
    private float TimeSum = 0f; // 시간이 누적될 변수

    public void SpawnPlatform(int stage)
    {
        float randomY = Random.Range(MinYpos, MaxYpos); // 스포너사이의 랜덤 공간 지정하기
        int randnum = Random.Range(1, 3); // 1 혹은 2 ( 플랫폼 종류를 두 가지 중에서 정하기 )

        switch (stage)
        {
            case 1:
                if (randnum == 1)
                {
                    Instantiate(platform1_1, new Vector3(transform.position.x, randomY, 0), Quaternion.identity);
                }
                else
                {
                    Instantiate(platform1_2, new Vector3(transform.position.x, randomY, 0), Quaternion.identity);
                }
                break;
            case 2:
                if (randnum == 1)
                {
                    Instantiate(platform2_1, new Vector3(transform.position.x, randomY, 0), Quaternion.identity);
                }
                else
                {
                    Instantiate(platform2_2, new Vector3(transform.position.x, randomY, 0), Quaternion.identity);
                }
                break;
            case 3:
                if (randnum == 1)
                {
                    Instantiate(platform3_1, new Vector3(transform.position.x, randomY, 0), Quaternion.identity);
                }
                else
                {
                    Instantiate(platform3_2, new Vector3(transform.position.x, randomY, 0), Quaternion.identity);
                }
                break;
        }
    }

    public int GetScore() //현재 스코어 반환
    {
        return Score;
    }

    public void UpdatePlatformSpeed(float newspeed)
    {
        CurrentSpeed = newspeed;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>(); // 스포너의 스프라이트 렌더러를 갖고 온다. 

        // 현재 스포너의 최대, 최소 높이 y좌표를 갖고 오기
        MaxYpos = spriteRenderer.bounds.max.y;
        MinYpos = spriteRenderer.bounds.min.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager != null)
        {
            CurrentStage = gameManager.CurrentStage;
            Debug.Log("gamemanger 참조 성공" + CurrentStage);
        }

        TimeSum += Time.deltaTime; // 초마다 더한다. 

        if (TimeSum >= SpawnDuration) // 스폰 주기를 채웠다면
        {
            Debug.Log("플랫폼 생성!");
            SpawnPlatform(CurrentStage); // 현재 스테이지의 정보를 주고 플랫폼 스폰 함수 호출
            TimeSum = 0f; // 다시 시간을 측정하기 시작
        }
    }
}
