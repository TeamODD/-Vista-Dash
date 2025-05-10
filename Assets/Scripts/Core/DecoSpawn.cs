using UnityEditor.Build.Content;
using UnityEditor.SceneManagement;
using UnityEngine;

public class DecoSpawner : MonoBehaviour
{
    int decoRand;
    
    GameManager GameManager;
    int Stage; 
    [SerializeField] Transform spawnPivot;

    // Decorations 
    [SerializeField] GameObject Deco1_1;
    [SerializeField] GameObject Deco1_2;
    [SerializeField] GameObject Deco1_3;
    [SerializeField] GameObject Deco1_4;
    [SerializeField] GameObject Deco2_1;
    [SerializeField] GameObject Deco2_2;
    [SerializeField] GameObject Deco2_3;
    [SerializeField] GameObject Deco2_4;
    [SerializeField] GameObject Deco3_1;
    [SerializeField] GameObject Deco3_2;
    [SerializeField] GameObject Deco3_3;
    [SerializeField] GameObject Deco3_4;
    void OnEnable()
    {
        if (GameManager != null) 
        {
            Stage = GameManager.CurrentStage; 

            spawnDeco(Stage); 
        }
        else
        {
            Debug.Log("게임 매니저 참조 오류");
        }
    }

    private void spawnDeco(int stage) 
    {
        switch (stage)
        {
            case 1:
                spawnDeco1();
                break;
            case 2:
                spawnDeco2();
                break;
            case 3:
                spawnDeco3();
                break;
        }
    }

    void spawnDeco1()
    {
        decoRand = Random.Range(1, 5); // 1부터 4까지

        switch(decoRand)
        {
            case 1: 
                Instantiate(Deco1_1, spawnPivot);
                break;
            case 2:
                Instantiate(Deco1_2, spawnPivot);
                break;
            case 3:
                Instantiate(Deco1_3, spawnPivot);
                break;
            case 4:
                Instantiate(Deco1_4, spawnPivot);
                break;                
        }
    }

    void spawnDeco2()
    {
        decoRand = Random.Range(1, 5); // 1부터 4까지

        switch(decoRand)
        {
            case 1: 
                Instantiate(Deco2_1, spawnPivot);
                break;
            case 2:
                Instantiate(Deco2_2, spawnPivot);
                break;
            case 3:
                Instantiate(Deco2_3, spawnPivot);
                break;
            case 4:
                Instantiate(Deco2_4, spawnPivot);
                break;                
        }
    }

    void spawnDeco3()
    {
        decoRand = Random.Range(1, 5); // 1부터 4까지

        switch(decoRand)
        {
            case 1: 
                Instantiate(Deco3_1, spawnPivot);
                break;
            case 2:
                Instantiate(Deco3_2, spawnPivot);
                break;
            case 3:
                Instantiate(Deco3_3, spawnPivot);
                break;
            case 4:
                Instantiate(Deco3_4, spawnPivot);
                break;                
        }
    }
}