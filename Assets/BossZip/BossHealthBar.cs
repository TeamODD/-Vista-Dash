using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    BossHealth bossHealth;
    [SerializeField] Slider slider;
    void Update()
    {
        bossHealth = FindAnyObjectByType<BossHealth>();

        if(bossHealth != null)
        {
            slider.maxValue = bossHealth.InitLife;
            slider.value = bossHealth.CurrentLife;
            gameObject.transform.localPosition = new Vector3(0, 0, 0);
        }
        else
        {
            gameObject.transform.localPosition = new Vector3(0, -140, 0);
        }
    }
}
