using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour, IDamagable
{
    [SerializeField] float InitLife = 100;
    [SerializeField] float CurrentLife;
    [SerializeField] GameObject Tombstone; // 적 캐릭터가 사망 시 생성할 무덤 객체
    [SerializeField] Slider bossSlider; // 보스 캐릭터의 체력바

    public GameManager gameManager;
    void Start()
    {
        CurrentLife = InitLife; // 체력 초기화
        gameManager = FindAnyObjectByType<GameManager>();
        gameManager.SpawnBoss();
    }

    public void Damage(float damage)
    {
        CurrentLife -= damage;

        if(CurrentLife <= 0)
        {
            Die(); // 사망 처리
        }
    }

    void Die()
    {
        // 무덤 객체 생성할 로직
        gameManager.RemoveBoss();
        Destroy(gameObject); // 스스로를 파괴
    }

    void updateSlider() // 체력바를 갱신
    {
        bossSlider.value = CurrentLife;
    }

}
