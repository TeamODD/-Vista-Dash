using UnityEngine;

public class HealItem : MonoBehaviour
{
    [SerializeField] float heal; // 회복량
    IHealable healable; // 회복 인터페이스
    void OnTriggerEnter2D(Collider2D collision)
    {
        healable = collision.GetComponent<IHealable>(); // 충돌한 객체의 회복 인터페이스 가져오기 시도

        if(healable!=null) // 회복 인터페이스가 존재한다면
        {
            healable.Heal(heal); // 회복량 만큼 회복 함수 실행
        }

        Destroy(gameObject); // 스스로를 파괴
    }
}
