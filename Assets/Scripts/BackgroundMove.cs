using UnityEngine;

public class InfiniteScrollBackground : MonoBehaviour
{
    public GameObject background1;
    public GameObject background2;
    public float scrollSpeed = 2f;

    private float backgroundWidth;

    void Start()
    {
        // 배경 1장의 너비 계산
        backgroundWidth = background1.GetComponent<SpriteRenderer>().bounds.size.x;

        // background2를 background1의 오른쪽에 위치시킴
        background2.transform.position = new Vector3(
            background1.transform.position.x + backgroundWidth,
            background1.transform.position.y,
            background1.transform.position.z
        );
    }

    void Update()
    {
        // 두 배경을 왼쪽으로 이동
        //background1.transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);
        //background2.transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);

        // 배경이 왼쪽으로 화면 밖으로 나가면 오른쪽으로 재배치
        if (background1.transform.position.x <= -backgroundWidth)
        {
            background1.transform.position = new Vector3(
                background2.transform.position.x + backgroundWidth,
                background1.transform.position.y,
                background1.transform.position.z
            );
        }

        if (background2.transform.position.x <= -backgroundWidth)
        {
            background2.transform.position = new Vector3(
                background1.transform.position.x + backgroundWidth,
                background2.transform.position.y,
                background2.transform.position.z
            );
        }
    }
}

