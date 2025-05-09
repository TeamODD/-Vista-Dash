 using UnityEngine;

public class RemoveItems : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject.name +"에 충돌함");
        
        if ((other.gameObject.tag != "BackGround") && (other.gameObject.tag != "Player")) 
        {
                Destroy(other.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name + "에 충돌함 (Trigger)");

        if ((other.gameObject.tag != "BackGround") && (other.gameObject.tag != "Player"))
        {
            Destroy(other.gameObject);
        }
    }
}
