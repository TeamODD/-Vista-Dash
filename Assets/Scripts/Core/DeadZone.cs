using UnityEngine;

public class DeadZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        // 플레이어가 닿는다면 PlayerHealth 컴포넌트를 참조하고 Die() 함수를 실행한다.
        PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>(); // 플레이어 헬스 컴포넌트를 참조하기

        if(playerHealth != null) // 참조 성공 시
        {
            playerHealth.Die();
        }
    }
}
