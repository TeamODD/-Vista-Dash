using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadEndingScene : MonoBehaviour
{
   
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("NextStage"))
        {
            Debug.Log("다음 씬으로로");
            SceneManager.LoadScene("MainMenu");
        }    
    }
}
