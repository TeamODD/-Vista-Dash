using UnityEditor.Build.Content;
using UnityEditor.SceneManagement;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    // ������ �� ��ü ( 1�������� �ϳ�, 2�������� �� ��, 3 ���������� �ܵ� ������. ��, �ܵ� ��ũ��Ʈ )
    [SerializeField] GameObject Enemy1_1;
    [SerializeField] GameObject Enemy2_1;
    [SerializeField] GameObject Enemy2_2;
    // ������ ���� ����
    int enemyRand;
    int decoRand;
    // ���� ������Ʈ
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
        int enemyRand = Random.Range(1, 5); // 1~4

        switch (enemyRand)
        {
            case 1:
                Instantiate(Enemy1_1, spawnPivot.position, Quaternion.identity);
                break;
            default:
                // 75% Ȯ���� �ƹ��͵� �� ����
                break;
        }
    }

    void spawnEnemy_2()
    {
        int enemyRand = Random.Range(1, 12); // 1~11

        if (enemyRand <= 5)
        {
            // 50% Ȯ���� �ƹ��͵� �� ����
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
            // 50% Ȯ���� �ƹ��͵� �� ����
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
        spawnEnemy(2); // �� ��ü�� ���� ( ����׿� �Ŵ��� ���� )
        spawnDeco(2); // ����� ���� ( ����׿� �Ŵ��� ���� )

        if (GameManager != null) // ���� �Ŵ����� ���������� �����ߴٸ�
        {
            Stage = GameManager.CurrentStage; // ���� �Ŵ������� ���� ���������� �޾ƿ�.

            spawnEnemy(Stage); // �� ��ü�� ���� 
            spawnDeco(Stage); // ����� ����
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

    private void spawnDeco(int stage) // ��� ���� ���� ���̺� ( ���ҽ� ���� ���� ���� )
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