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
    [SerializeField] GameObject MusicUI_1;
    [SerializeField] GameObject MusicUI_2;
    [SerializeField] GameObject MusicUI_3;
    [SerializeField] GameObject bossAlertMessage;

    //public GameObject cutScene;

    [SerializeField] private GameObject Boss1;
    [SerializeField] private int S1boss = 15;
    [SerializeField] private GameObject Boss2;
    [SerializeField] private int S2boss = 45;
    [SerializeField] private GameObject Boss3;
    [SerializeField] private int S3boss = 75;

    [SerializeField] private int S1toS2 = 30;
    [SerializeField] private int S2toS3 = 60;

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
    public int dieboss = 0;

    //public float cutSceneSeconds = 10f; 
    //public float cutSceneSpeed = 4f;  //컷신 움직이는 속도

    //private bool cutSceneCount = false;

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
        MusicUI_1.SetActive(true);
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
        if (((CurrentStage == 1 && CurrentScore >= S1toS2) && Spawner.PlatformCount >= S1toS2) && bosslog == 1)  // 2�������� ���Խ�
        {
            MusicUI_2.SetActive(true);

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
        else if (((CurrentStage == 2 && CurrentScore >= S2toS3) && Spawner.PlatformCount >= S2toS3) && bosslog == 2) // 3�������� ���Խ�
        {
            MusicUI_3.SetActive(true);

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
        if (((CurrentStage == 1 && Spawner.PlatformCount >= S1boss) && isBoss == false) && bosslog == 0)
        {
            bossAlertMessage.SetActive(true);
            Instantiate(Boss1, new Vector3(10, 10, 0), Quaternion.identity);
            bosslog++;
        }
        else if (((CurrentStage == 2 && Spawner.PlatformCount >= S2boss) && isBoss == false) && bosslog == 1)
        {
            bossAlertMessage.SetActive(true);
            Instantiate(Boss2, new Vector3(10, 10, 0), Quaternion.identity);
            bosslog++;
        }
        else if (((CurrentStage == 3 && Spawner.PlatformCount >= S3boss)&&isBoss == false) && bosslog == 2)
        {
            bossAlertMessage.SetActive(true);
            Instantiate(Boss3, new Vector3(10, 10, 0), Quaternion.identity);
            bosslog++;
        }
    }
}
