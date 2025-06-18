using UnityEngine;
using UnityEngine.SceneManagement;

public class StartCutSceneMenu : MonoBehaviour
{
    public GameObject spedUp;
    public GameObject slowDown;
    public SpriteRenderer SpawnPivot;
    public ScrollingObject Image;
    int MaxXpos;
    int MinXpos;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("NextStage"))
        {
            Debug.Log("다음 씬으로로");
            SceneManager.LoadScene("SampleScene");
        }    
    }

    public void SkipCutscene()
    {
        SceneManager.LoadScene("SampleScene");   
    }

    void Start()
    {
        SpawnPivot = SpawnPivot.GetComponent<SpriteRenderer>();        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            Image.leftSpeed += 1;

            MaxXpos = (int)SpawnPivot.bounds.max.x;   
            MinXpos = (int)SpawnPivot.bounds.min.x;

            int xPos = Random.Range(MinXpos, MaxXpos);     

            Instantiate(spedUp, new Vector3(xPos, -6, 0), Quaternion.identity);       
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(Image.leftSpeed <= 1)
            {
                return; 
            }
            
            Image.leftSpeed -= 1;
        
            MaxXpos = (int)SpawnPivot.bounds.max.x;   
            MinXpos = (int)SpawnPivot.bounds.min.x;

            int xPos = Random.Range(MinXpos, MaxXpos);     

            Instantiate(slowDown, new Vector3(xPos, -5, 0), Quaternion.identity);   
        }
    }
}
