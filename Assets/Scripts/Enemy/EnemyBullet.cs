 using UnityEngine;
using UnityEngine.UI;

public class EnemyBullet : MonoBehaviour, IDamagable
{
    [SerializeField] float currentLife = 1;
    [SerializeField] float bulletDamage = 1;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player") // 충돌한 객체의 태그가 Player 라면
        {
            IDamagable damagable = collision.GetComponent<IDamagable>();

            damagable.Damage(bulletDamage);
        }
    }

    public void Damage(float damage)
    {
        currentLife -= damage;

        if(currentLife<=0)
        {
            Destroy(gameObject); // 탄환 자신의 체력이 0이라면 자신을 파괴
        }
    }
}
