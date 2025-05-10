using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamagable
{
    [SerializeField] float InitLife = 1;
    [SerializeField] float CurrentLife;
    [SerializeField] float MeleeDamage; // 캐릭터가 적에 닿았을 때 줄 대미지
    [SerializeField] GameObject Tombstone; // 적 캐릭터가 사망 시 생성할 무덤 객체
    PlayerAttack playerAttack; // 적 객체가 사망 후 플레이어에게 탄환을 충전하기 위해 참조할 플레이어 공격 스크립트
    [SerializeField] int dropAmmo; // 적 객체가 사망 후 플레이어에게 줄 탄환 수
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
            playerAttack = FindAnyObjectByType<PlayerAttack>();

            playerAttack.bulletCount += dropAmmo; // 플레이어에게 탄환을 충전한다.

            Invoke("Die", 0.1f); // 사망처리 지연
        }
    }

    void Die()
    {
        // 무덤 객체 생성할 로직
        Destroy(gameObject); // 스스로를 파괴
    }
}
