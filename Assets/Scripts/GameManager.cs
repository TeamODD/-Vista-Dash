using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //배경 연결
    public GameObject Stage1_1;
    public GameObject Stage1_2;  
    public GameObject Stage2_1;
    public GameObject Stage2_2;
    public GameObject Stage3_1;
    public GameObject Stage3_2;

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
    
      
        Stage1_1.SetActive(true);
        Stage1_2.SetActive(true);
        Stage2_1.SetActive(false);
        Stage2_2.SetActive(false);
       
    }


    /*
        IEnumerator TestTime()
        {
            yield return new WaitForSeconds(2f);
            CurrentScore = 10;
        }
    */
    // Update is called once per frame
    void Update()
    {
        int CurrentScore = Spawner.GetScore(); // PlatformSpawner���� ���� ���ھ� �޾ƿ�
        Debug.Log("스코어" +  CurrentScore + "스테이지" + CurrentStage + "속도" + CurrentSpeed);
        if (CurrentStage == 1 && CurrentScore >= 10) // 2�������� ���Խ�
        {
            Stage1_1.SetActive(false);
            Stage1_2.SetActive(false);
            Stage2_1.SetActive(true);
            Stage2_2.SetActive(true);
            Debug.Log("스테이지2 배경 켜짐");
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
