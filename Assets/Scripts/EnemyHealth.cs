using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamagable
{
    [SerializeField] float InitLife = 1;
    [SerializeField] float CurrentLife;
    [SerializeField] float MeleeDamage; // 캐릭터가 적에 닿았을 때 줄 대미지
    [SerializeField] GameObject Tombstone; // 적 캐릭터가 사망 시 생성할 무덤 객체
    void Start()
    {
        CurrentLife = InitLife; // 체력 초기화  
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player") // 플레이어 객체와 충돌했다면 근접 대미지 주기
        {
            IDamagable damagable = collision.GetComponent<IDamagable>(); // 플레이어의 대미지 인터페이스 가져오기

            damagable.Damage(MeleeDamage);
        }
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
        Destroy(gameObject); // 스스로를 파괴
    }
}
