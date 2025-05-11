using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour, IDamagable
{
    [SerializeField] float InitLife = 100;
    [SerializeField] float CurrentLife;
    [SerializeField] GameObject Tombstone; // 적 캐릭터가 사망 시 생성할 무덤 객체
    [SerializeField] Slider bossSlider; // 보스 캐릭터의 체력바
    [SerializeField] GameObject hitEffect1; // 피격 이펙트 1
    [SerializeField] GameObject hitEffect2; // 피격 이펙트 2
    [SerializeField] GameObject hitEffect3; // 피격 이펙트 3
    [SerializeField] GameObject hitEffect4; // 피격 이펙트 4
    public GameManager gameManager;
    void Start()
    {
        CurrentLife = InitLife; // 체력 초기화
        gameManager = FindAnyObjectByType<GameManager>();
        gameManager.SpawnBoss();
    }

    public void Damage(float damage)
    {
        int rannum = Random.Range(1, 5); // 1부터 4까지 랜덤으로 생성

        switch(rannum)
        {
            case 1:
                Instantiate(hitEffect1, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                break;
            case 2:
                Instantiate(hitEffect2, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                break;
            case 3:
                Instantiate(hitEffect3, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                break;
            case 4:
                Instantiate(hitEffect4, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                break;
        }

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
