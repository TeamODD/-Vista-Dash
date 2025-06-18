using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject Glitch;
    public void StartButton()
    {
        SceneManager.LoadScene("StartCutScene");
    }

    public void CreditsButton()
    {
        SceneManager.LoadScene("Credit");
    }

    public void RuleButton()
    {
        SceneManager.LoadScene("GameRule");
    }

    public void EasterEgg()
    {
        Instantiate(Glitch, Vector3.zero, Quaternion.identity);
    }
}
