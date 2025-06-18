using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] GameObject Enemy1_1; // 토끼 1
    [SerializeField] GameObject Enemy1_1_1; // 토끼 2
    [SerializeField] GameObject Enemy2_1; // 스피커 1
    [SerializeField] GameObject Enemy2_1_1; // 스피커 2
    [SerializeField] GameObject Enemy2_2_1; // 모니터 1
    [SerializeField] GameObject Enemy2_2_2; // 모니터 2
    [SerializeField] GameObject healItem;
    [SerializeField] GameObject ammoItem;

    int Stage;
    GameManager GameManager;
    [SerializeField] Transform spawnPivot;

    // 스테이지 1 : 스폰 안함 50%, 탄약 10%, 힐 아이템 10%, 토끼 1 30%
    // 스테이지 2 : 스폰 안함 50%, 탄약 10%, 힐 아이템 10%, 토끼 1 10%, 스피커 1 10%, 모니터 1 10%
    // 스테이지 3 : 스폰 안함 40%, 탄약 10%, 힐 아이템 10%, 토끼 2 10%, 스피커 2 15%, 모니터 2 15%

    void OnEnable()
    {
        GameManager = FindAnyObjectByType<GameManager>();

        if (GameManager != null)
        {
            Stage = GameManager.CurrentStage;
            spawnEnemy(Stage);
        }
        else
        {
            Debug.Log("ItemSpawner 게임 매니저 참조 오류");
        }
    }

    private void spawnEnemy(int stage)
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

    void spawnEnemy_1()
    {
        int rand = Random.Range(0, 100);

        if (rand < 10)
        {
            Instantiate(ammoItem, spawnPivot.position, Quaternion.identity); // 0~9 (10%)
        }
        else if (rand < 20)
        {
            Instantiate(healItem, spawnPivot.position, Quaternion.identity); // 10~19 (10%)
        }
        else if (rand < 50)
        {
            Instantiate(Enemy1_1, spawnPivot.position, Quaternion.identity); // 20~49 (30%)
        }
        // 50~99 (50%) = 스폰 안 함
    }

    void spawnEnemy_2()
    {
        int rand = Random.Range(0, 100);

        if (rand < 10)
        {
            Instantiate(ammoItem, spawnPivot.position, Quaternion.identity); // 0~9 (10%)
        }
        else if (rand < 20)
        {
            Instantiate(healItem, spawnPivot.position, Quaternion.identity); // 10~19 (10%)
        }
        else if (rand < 30)
        {
            Instantiate(Enemy1_1, spawnPivot.position, Quaternion.identity); // 20~29 (10%)
        }
        else if (rand < 40)
        {
            Instantiate(Enemy2_1, spawnPivot.position, Quaternion.identity); // 30~39 (10%)
        }
        else if (rand < 50)
        {
            Instantiate(Enemy2_2_1, spawnPivot.position, Quaternion.identity); // 40~49 (10%)
        }
        // 50~99 (50%) = 스폰 안 함
    }

    void spawnEnemy_3()
    {
        int rand = Random.Range(0, 100);

        if (rand < 10)
        {
            Instantiate(ammoItem, spawnPivot.position, Quaternion.identity); // 0~9 (10%)
        }
        else if (rand < 20)
        {
            Instantiate(healItem, spawnPivot.position, Quaternion.identity); // 10~19 (10%)
        }
        else if (rand < 30)
        {
            Instantiate(Enemy1_1_1, spawnPivot.position, Quaternion.identity); // 20~29 (10%)
        }
        else if (rand < 45)
        {
            Instantiate(Enemy2_1_1, spawnPivot.position, Quaternion.identity); // 30~44 (15%)
        }
        else if (rand < 60)
        {
            Instantiate(Enemy2_2_2, spawnPivot.position, Quaternion.identity); // 45~59 (15%)
        }
        // 60~99 (40%) = 스폰 안 함
    }
}