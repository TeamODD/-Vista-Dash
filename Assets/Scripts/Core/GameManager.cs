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

    public GameObject testBoss;

    public PlatformSpawner Spawner; //PlatformSpawner �� Spawner�� �ҷ���
    public ScrollingObject scrollingObject;

    public AudioSource stage1Music;
    public AudioSource stage2Music;
    public AudioSource stage3Music;

    public int CurrentStage = 1; //���� ���������� = 1

    public float Stage2Multiple = 1.2f;
    public float Stage3Multiple = 1.5f;
    public float CurrentSpeed = 10.0f;

    public bool isBoss = false;
    public int bosslog = 0;
    public void SpawnBoss()
    {
        isBoss = true;
    }

    public void RemoveBoss()
    {
        isBoss = false;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Spawner = FindAnyObjectByType<PlatformSpawner>();
        Spawner.UpdatePlatformSpeed(CurrentSpeed); // PlatformSpawner�� Speed�� ���� �ӵ��� ����
        scrollingObject = FindAnyObjectByType<ScrollingObject>();
        stage1Music = GetComponent<AudioSource>();
        stage2Music = GetComponent<AudioSource>();
        stage3Music = GetComponent<AudioSource>();

        //stage1Music.Play();
        //stage3Music.Stop();
        Stage1_1.SetActive(true);
        Stage1_2.SetActive(true);
        Stage2_1.SetActive(false);
        Stage2_2.SetActive(false);
        Stage3_1.SetActive(false);
        Stage3_2.SetActive(false);

       
    }

    // Update is called once per frame
    void Update()
    {
        int CurrentScore = Spawner.GetScore(); // PlatformSpawner���� ���� ���ھ� �޾ƿ�
        Debug.Log("스코어" +  CurrentScore + "스테이지" + CurrentStage + "속도" + CurrentSpeed + "보스로그" + bosslog);
        if (((CurrentStage == 1 && CurrentScore >= 30) && Spawner.PlatformCount >= 30) && bosslog == 1)  // 2�������� ���Խ�
        {
            //stage1Music.Stop();
            //stage2Music.Play();
            Stage1_1.SetActive(false);
            Stage1_2.SetActive(false);
            Stage2_1.SetActive(true);
            Stage2_2.SetActive(true);
            Stage3_1.SetActive(false);
            Stage3_2.SetActive(false);
            Debug.Log("스테이지2 배경 켜짐");
            CurrentStage = 2;
            /* 
            CurrentSpeed = CurrentSpeed * Stage2Multiple; // 1.2�� == 12f
            Spawner.UpdatePlatformSpeed(CurrentSpeed); // ������
            scrollingObject.UpdateSpeed(CurrentSpeed); // ��ũ�Ѹ� �Ѵ� �ӵ� ����
            */
        }
        else if (((CurrentStage == 2 && CurrentScore >= 60) && Spawner.PlatformCount >= 60) && bosslog == 2) // 3�������� ���Խ�
        {
            //stage2Music.Stop();
            //stage3Music.Play();
            Stage1_1.SetActive(false);
            Stage1_2.SetActive(false);
            Stage2_1.SetActive(false);
            Stage2_2.SetActive(false);
            Stage3_1.SetActive(true);
            Stage3_2.SetActive(true);
            CurrentStage = 3;
            /*
            CurrentSpeed = CurrentSpeed * Stage3Multiple; // 1.5�� == 18f
            Spawner.UpdatePlatformSpeed(CurrentSpeed);
            scrollingObject.UpdateSpeed(CurrentSpeed);
            */
        }
    }

    private void FixedUpdate()
    {
        if (((CurrentStage == 1 && Spawner.PlatformCount >= 15) && isBoss == false) && bosslog == 0)
        {
            testBoss.SetActive(true);
            bosslog++;
        }
        else if (((CurrentStage == 2 && Spawner.PlatformCount >= 45) && isBoss == false) && bosslog == 1)
        {
            testBoss.SetActive(true);
            bosslog++;
        }
        else if (((CurrentStage == 3 && Spawner.PlatformCount >= 70)&&isBoss == false) && bosslog == 2)
        {
            testBoss.SetActive(true);
            bosslog++;
        }
    }
}
