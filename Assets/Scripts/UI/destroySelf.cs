using UnityEngine;

public class destroySelf : MonoBehaviour
{
    [SerializeField] float yForce; // y축으로 얼마만큼 튀어오를 지
    [SerializeField] float seconds = 1f; // 몇 초 뒤 삭제
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.AddForce(Vector2.up * yForce, ForceMode2D.Impulse); // y축으로 힘을 준다.

        Invoke("DestroySelf", seconds);
    }

    void DestroySelf()
    {
        Destroy(gameObject); // 스스로를 파괴
    }
}
