using UnityEditor.Build.Content;
using UnityEditor.SceneManagement;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    // ������ �� ��ü ( 1�������� �ϳ�, 2�������� �� ��, 3 ���������� �ܵ� ������. ��, �ܵ� ��ũ��Ʈ )
    [SerializeField] GameObject Enemy1_1;
    [SerializeField] GameObject Enemy2_1;
    [SerializeField] GameObject Enemy2_2;
    [SerializeField] GameObject healItem;
    [SerializeField] GameObject ammoItem;
    // ������ ���� ����
    int enemyRand;
    GameManager GameManager;
    int Stage; // ���� �������� ��ȣ�� ������ ����
    [SerializeField] Transform spawnPivot; // �������� ������ �ڸ�

    // �� ���� Ȯ�� �Լ� ������

    // �������� 1 -> 
    // 75% Ȯ���� �� ���̺�
    // 25% Ȯ���� Enemy1_1 ����

    // �������� 2 -> 
    // 50% Ȯ���� �� ���̺� 
    // 15% Ȯ���� Enemy1_1 ����
    // 25% Ȯ���� Enemy2_1 ����
    // 10% Ȯ���� Enemy2_2 ����

    // �������� 3 -> 
    // 50% Ȯ���� �� ���̺� 
    // 30% Ȯ���� Enemy2_1 ����
    // 20% Ȯ���� Enemy2_2 ����

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
        // 50~99 (50%)는 아무 일도 없음
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
            Instantiate(Enemy2_2, spawnPivot.position, Quaternion.identity); // 40~49 (10%)
        }
        // 50~99 (50%)는 빈 칸
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
        else if (rand < 35)
        {
            Instantiate(Enemy2_1, spawnPivot.position, Quaternion.identity); // 20~34 (15%)
        }
        else if (rand < 50)
        {
            Instantiate(Enemy2_2, spawnPivot.position, Quaternion.identity); // 35~49 (15%)
        }
        // 50~99 (50%)는 빈 칸
    }

    void OnEnable()
    {
        spawnEnemy(2); // �� ��ü�� ���� ( ����׿� �Ŵ��� ���� )

        if (GameManager != null) // ���� �Ŵ����� ���������� �����ߴٸ�
        {
            Stage = GameManager.CurrentStage; // ���� �Ŵ������� ���� ���������� �޾ƿ�.

            spawnEnemy(Stage); // �� ��ü�� ���� 
        }
        else
        {
            Debug.Log("���� �Ŵ��� ���� ����");
        }
    }

    private void spawnEnemy(int stage) // �� ���� ���� ���̺�
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
}