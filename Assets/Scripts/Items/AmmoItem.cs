using UnityEngine;

public class AmmoItem : MonoBehaviour
{
    [SerializeField] int ammo; // 탄환 충전량
    PlayerAttack playerAttack; // 플레이어 탄환 컴포넌트
    void OnTriggerEnter2D(Collider2D collision)
    {
        playerAttack = collision.GetComponent<PlayerAttack>();

        if(playerAttack != null) // 플레이어 공격 컴포넌트를 가져오는 데 성공 했다면
        {
            playerAttack.addAmmo(ammo);
            Destroy(gameObject); // 스스로를 파괴
        }
    }
}
