using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlatformSpawner Spawner;
    public int CurrentStage = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        int CurrentScore = Spawner.GetScore();

        if (CurrentScore >= CurrentStage * 10) 
        {
            CurrentStage++;
        }
    }
}
