 using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] float bulletDamage = 1.0f;

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        IDamagable damagable = collision.GetComponent<IDamagable>(); // 적이 인터페이스가 있는지 확인

        if(damagable!=null) // 충돌한 객체가 적 혹은 적의 탄환이라면
        {
            damagable.Damage(bulletDamage); // bulletDamage (1) 만큼 대미지를 입힌다. 

            Destroy(gameObject); // 대미지를 입힌 뒤 자신 파괴
        }
    }
}