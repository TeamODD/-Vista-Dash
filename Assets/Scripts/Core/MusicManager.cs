using UnityEngine;

public class MusicManager : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip BGM_1; // 배경 음악 1
    [SerializeField] AudioClip BGM_2; // 배경 음악 2
    [SerializeField] AudioClip BGM_3; // 배경 음악 3
    [SerializeField] GameManager gameManager;
    void Update()
    {
        UpdateMusic(gameManager.CurrentStage); // 현재 스테이지를 받아와서 배경 음악을 업데이트
    }

    void UpdateMusic(int stage)
    {
        switch(stage) // 스
        {
            case 1:
                audioSource.clip = BGM_1;
                break;
            case 2:
                audioSource.clip = BGM_2;
                break;
            case 3:
                audioSource.clip = BGM_3;
                break;
        }
    }
}
