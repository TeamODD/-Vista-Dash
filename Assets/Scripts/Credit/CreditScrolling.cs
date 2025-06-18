using UnityEngine;

public class CreditScrolling : MonoBehaviour
{

    private BackgroundMove backgroundMove;

    private float backgroundWidth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {      
        backgroundMove = FindAnyObjectByType<BackgroundMove>();
        // 배경 1장의 너비 계산
        backgroundWidth = backgroundMove.background1.GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        // 두 배경을 왼쪽으로 이동
        //background1.transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);
        //background2.transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);

        // 배경이 왼쪽으로 화면 밖으로 나가면 오른쪽으로 재배치
        if (transform.position.x <= -backgroundWidth)
        {
            transform.position = new Vector3(
                transform.position.x + (backgroundWidth) * 6,
                transform.position.y,
                transform.position.z
            );
        }
    }
}
