using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlatformSpawner Spawner; //PlatformSpawner �� Spawner�� �ҷ���
    public ScrollingObject ScrollingObject;

    public int CurrentStage = 1; //���� ���������� = 1

    public float Stage2Multiple = 1.2f; 
    public float Stage3Multiple = 1.5f;

    public float CurrentSpeed = 10.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Spawner = FindAnyObjectByType<PlatformSpawner>();
        Spawner.UpdatePlatformSpeed(CurrentSpeed); // PlatformSpawner�� Speed�� ���� �ӵ��� ����
    }

    // Update is called once per frame
    void Update()
    {
        int CurrentScore = Spawner.GetScore(); // PlatformSpawner���� ���� ���ھ� �޾ƿ�

        if (CurrentStage == 1 && CurrentScore >= 10) // 2�������� ���Խ�
        {
            CurrentStage = 2; 
            CurrentSpeed = CurrentSpeed * Stage2Multiple; // 1.2�� == 12f
            Spawner.UpdatePlatformSpeed(CurrentSpeed); // ������
            ScrollingObject.UpdateSpeed(CurrentSpeed); // ��ũ�Ѹ� �Ѵ� �ӵ� ����
        }
        else if (CurrentStage == 2 && CurrentScore >= 20) // 3�������� ���Խ�
        {
            CurrentStage = 3;
            CurrentSpeed = CurrentSpeed * Stage3Multiple; // 1.5�� == 18f
            Spawner.UpdatePlatformSpeed(CurrentSpeed);
            ScrollingObject.UpdateSpeed(CurrentSpeed);
        }
    }
}
