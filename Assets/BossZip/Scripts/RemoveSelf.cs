using UnityEngine;

public class RemoveSelf : MonoBehaviour
{
    [SerializeField] float seconds;
    void Start()
    {
        Invoke("destroySelf", seconds);
    }

    void destroySelf()
    {
        Destroy(gameObject);
    }
}
