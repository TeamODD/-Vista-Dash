 using UnityEngine;

public class RemoveItems : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.tag != "BackGround") && (other.gameObject.tag != "Player")) 
            {
                Destroy(other);
            }
    }
}
