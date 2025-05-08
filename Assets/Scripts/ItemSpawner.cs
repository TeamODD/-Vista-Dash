using UnityEditor.Build.Content;
using UnityEditor.SceneManagement;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    // 스폰할 적 객체 ( 1스테이지 하나, 2스테이지 두 개, 3 스테이지는 단독 보스몹. 즉, 단독 스크립트 )
    [SerializeField] GameObject Enemy1_1;
    [SerializeField] GameObject Enemy2_1;
    [SerializeField] GameObject Enemy2_2;
    // 난수에 사용될 변수
    int enemyRand;
    int decoRand;
    // 사용될 컴포넌트
    GameManager GameManager;
    int Stage; // 현재 스테이지 번호를 저장할 변수
    [SerializeField] Transform spawnPivot; // 아이템이 생성될 자리

    // 적 스폰 확률 함수 구현부

    // 스테이지 1 -> 
    // 75% 확률로 빈 테이블
    // 25% 확률로 Enemy1_1 생성

    // 스테이지 2 -> 
    // 50% 확률로 빈 테이블 
    // 15% 확률로 Enemy1_1 생성
    // 25% 확률로 Enemy2_1 생성
    // 10% 확률로 Enemy2_2 생성

    // 스테이지 3 -> 
    // 50% 확률로 빈 테이블 
    // 30% 확률로 Enemy2_1 생성
    // 20% 확률로 Enemy2_2 생성

    void spawnEnemy_1()
    {
        int enemyRand = Random.Range(1, 5); // 1~4

        switch (enemyRand)
        {
            case 1:
                Instantiate(Enemy1_1, spawnPivot.position, Quaternion.identity);
                break;
            default:
                // 75% 확률로 아무것도 안 나옴
                break;
        }
    }

    void spawnEnemy_2()
    {
        int enemyRand = Random.Range(1, 12); // 1~11

        if (enemyRand <= 5)
        {
            // 50% 확률로 아무것도 안 나옴
        }
        else if (enemyRand <= 7)
        {
            Instantiate(Enemy1_1, spawnPivot.position, Quaternion.identity);
        }
        else if (enemyRand <= 10)
        {
            Instantiate(Enemy2_1, spawnPivot.position, Quaternion.identity);
        }
        else // 11
        {
            Instantiate(Enemy2_2, spawnPivot.position, Quaternion.identity);
        }
    }

    void spawnEnemy_3()
    {
        int enemyRand = Random.Range(1, 11); // 1~10

        if (enemyRand <= 5)
        {
            // 50% 확률로 아무것도 안 나옴
        }
        else if (enemyRand <= 8)
        {
            Instantiate(Enemy2_1, spawnPivot.position, Quaternion.identity);
        }
        else // 9~10
        {
            Instantiate(Enemy2_2, spawnPivot.position, Quaternion.identity);
        }
    }
    void OnEnable()
    {
        spawnEnemy(2); // 적 객체를 생성 ( 디버그용 매니저 없이 )
        spawnDeco(2); // 장식을 생성 ( 디버그용 매니저 없이 )

        if (GameManager != null) // 게임 매니저를 성공적으로 참조했다면
        {
            Stage = GameManager.CurrentStage; // 게임 매니저에서 현재 스테이지를 받아옴.

            spawnEnemy(Stage); // 적 객체를 생성 
            spawnDeco(Stage); // 장식을 생성
        }
        else
        {
            Debug.Log("게임 매니저 참조 실패");
        }
    }

    private void spawnEnemy(int stage) // 적 생성 난수 테이블
    {
        switch (stage)
        {
            case 1:
                spawnEnemy_1();
                break;
            case 2:
                spawnEnemy_2();
                break;
            case 3:
                spawnEnemy_3();
                break;
        }
    }

    private void spawnDeco(int stage) // 장식 생성 난수 테이블 ( 리소스 이후 구현 예정 )
    {
        switch (stage)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
        }
    }
}