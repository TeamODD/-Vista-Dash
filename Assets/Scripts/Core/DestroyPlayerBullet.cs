using UnityEngine;

public class DestroyPlayerBullet : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        // 플레이어의 탄환이 닿았다면 삭제하기
        if(collision.gameObject.tag == "PlayerBullet")
        {
            Destroy(collision.gameObject);
        }
    }
}
