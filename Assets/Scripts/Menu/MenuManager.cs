using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject Glitch;
    public void StartButton()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void EasterEgg()
    {
        Instantiate(Glitch, Vector3.zero, Quaternion.identity);
    }
}
