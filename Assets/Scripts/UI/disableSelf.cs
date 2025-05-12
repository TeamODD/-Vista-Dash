using UnityEngine;

public class disableSelf : MonoBehaviour
{
    [SerializeField]float seconds;
    void Start()
    {
        Invoke("disable", seconds);
    }

    void disable()
    {
        gameObject.SetActive(false);
    }
}
