using UnityEngine;

public class RemoveSelf : MonoBehaviour
{
    [SerializeField] float seconds = 3f;
    void Start()
    {
        Invoke("destroySelf", seconds);
    }

    void destroySelf()
    {
        Destroy(gameObject);
    }
}
