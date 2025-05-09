using System.Threading;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public int Score = 0; //���ھ� �ʱⰪ 0

    public GameObject PlatformPrefeb;
    public ItemSpawner ItemSpawner;
    public GameManager gameManager;

    public float CurrentSpeed;
    int CurrentStage; // ���� �Ŵ������� ������ �������� ������ ����
    float MaxYpos; // ���� �������� �ִ� y�� ���� 
    float MinYpos; // ���� �������� �ּ� y�� ���� ->
    // �ּҿ��� �ִ� ����, �� ���簢�� ������ ������ ��ü�� ���̿��� �÷����� ���� ����
    // �������� ���� �ٸ� �������� ���� �÷��� ������ �� �� ( 4ĭ, 5ĭ )
    [SerializeField] GameObject platform1_1;
    [SerializeField] GameObject platform1_2;
    [SerializeField] GameObject platform2_1;
    [SerializeField] GameObject platform2_2;
    [SerializeField] GameObject platform3_1;
    [SerializeField] GameObject platform3_2;
    // ���� �ð� ���� ����
    [SerializeField] float SpawnDuration; // �ʸ��� �÷��� ����
    private float TimeSum = 0f; // �ð��� ������ ����

    public void SpawnPlatform(int stage)
    {
        float randomY = Random.Range(MinYpos, MaxYpos); // �����ʻ����� ���� ���� �����ϱ�
        int randnum = Random.Range(1, 3); // 1 Ȥ�� 2 ( �÷��� ������ �� ���� �߿��� ���ϱ� )

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

    public int GetScore() //���� ���ھ� ��ȯ
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
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>(); // �������� ��������Ʈ �������� ���� �´�. 

        // ���� �������� �ִ�, �ּ� ���� y��ǥ�� ���� ����
        MaxYpos = spriteRenderer.bounds.max.y;
        MinYpos = spriteRenderer.bounds.min.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager != null)
        {
            CurrentStage = gameManager.CurrentStage;
            Debug.Log("gamemanger ���� ����" + CurrentStage);
        }

        TimeSum += Time.deltaTime; // �ʸ��� ���Ѵ�. 

        if (TimeSum >= SpawnDuration) // ���� �ֱ⸦ ä���ٸ�
        {
            Debug.Log("�÷��� ����!");
            SpawnPlatform(CurrentStage); // ���� ���������� ������ �ְ� �÷��� ���� �Լ� ȣ��
            TimeSum = 0f; // �ٽ� �ð��� �����ϱ� ����
        }
    }
}
