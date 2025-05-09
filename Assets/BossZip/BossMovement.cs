using UnityEngine;

public class BossMovement : MonoBehaviour
{
    [SerializeField] float yLimit = 2f; // y축으로 이동할 최대 거리
    [SerializeField] float cycleTime = 2f; // 위에서 아래까지 가는 데 걸리는 시간 (초)

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // PingPong 함수는 0과 1 사이를 왕복하는 값을 생성함
        float t = Mathf.PingPong(Time.time / (cycleTime / 2f), 1f); // 위-아래 왕복 시간 기준
        float newY = Mathf.Lerp(-yLimit, yLimit, t); // -yLimit ~ +yLimit 사이 보간
        transform.position = new Vector3(startPos.x, startPos.y + newY, startPos.z);
    }
}
