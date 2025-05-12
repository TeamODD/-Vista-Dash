using UnityEngine;

public class BlasterGun : MonoBehaviour
{
    [SerializeField] GameObject attackLaser;
    [SerializeField] Transform attackPivot; // 공격 객체가 생성될 위치
    [SerializeField] float seconds; // seconds초 후에 공격을 생성
    void Start()
    {
        Invoke("StartAttack", seconds);
    }

    void StartAttack()
    {
        Instantiate(attackLaser, attackPivot.position, attackPivot.rotation);

        Invoke("destroySelf", 0.1f); // 0.1 초 후 스스로 ( 공격 예고 UI ) 를 삭제 생성과 동시에 삭제하면 버그
    }

    void destroySelf()
    {
        Destroy(gameObject);
    }
}
