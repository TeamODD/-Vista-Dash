using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public int Score = 0; //���ھ� �ʱⰪ 0
    public GameObject PlatformPrefeb;

    public float CurrentSpeed;
    public void SpawnPlatform()
    {

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
