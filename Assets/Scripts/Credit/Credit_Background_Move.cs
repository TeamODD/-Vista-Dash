using UnityEngine;

public class Credit_Background_Move : MonoBehaviour
{
    public GameObject Credit_background1;
    public GameObject Credit_background2;
    public GameObject Credit_background3;
    public GameObject Credit_background4;
    public GameObject Credit_background5;
    public GameObject Credit_background6;

    private float backgroundWidth;

    void Start()
    {
        // 배경 1장의 너비 계산
        backgroundWidth = Credit_background1.GetComponent<SpriteRenderer>().bounds.size.x;

        // background2를 background1의 오른쪽에 위치시킴
        Credit_background2.transform.position = new Vector3(
            Credit_background1.transform.position.x + backgroundWidth,
            Credit_background1.transform.position.y,
            Credit_background1.transform.position.z
        );
        Credit_background3.transform.position = new Vector3(
            Credit_background2.transform.position.x + backgroundWidth,
            Credit_background2.transform.position.y,
            Credit_background2.transform.position.z
        );
        Credit_background4.transform.position = new Vector3(
            Credit_background3.transform.position.x + backgroundWidth,
            Credit_background3.transform.position.y,
            Credit_background3.transform.position.z
        );
        Credit_background5.transform.position = new Vector3(
            Credit_background4.transform.position.x + backgroundWidth,
            Credit_background4.transform.position.y,
            Credit_background4.transform.position.z
        );
        Credit_background6.transform.position = new Vector3(
            Credit_background5.transform.position.x + backgroundWidth,
            Credit_background5.transform.position.y,
            Credit_background5.transform.position.z
        );
    }

    void Update()
    {
        // 두 배경을 왼쪽으로 이동
        //background1.transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);
        //background2.transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);

        // 배경이 왼쪽으로 화면 밖으로 나가면 오른쪽으로 재배치
        if (Credit_background1.transform.position.x <= -backgroundWidth)
        {
            Credit_background1.transform.position = new Vector3(
                Credit_background5.transform.position.x + (backgroundWidth),
                Credit_background1.transform.position.y,
                Credit_background1.transform.position.z
            );
        }

        if (Credit_background2.transform.position.x <= -backgroundWidth)
        {
            Credit_background2.transform.position = new Vector3(
                Credit_background1.transform.position.x + (backgroundWidth),
                Credit_background2.transform.position.y,
                Credit_background2.transform.position.z
            );
        }

        if (Credit_background3.transform.position.x <= -backgroundWidth)
        {
            Credit_background3.transform.position = new Vector3(
                Credit_background2.transform.position.x + (backgroundWidth),
                Credit_background3.transform.position.y,
                Credit_background3.transform.position.z
            );
        }

        if (Credit_background4.transform.position.x <= -backgroundWidth)
        {
            Credit_background4.transform.position = new Vector3(
                Credit_background3.transform.position.x + (backgroundWidth),
                Credit_background4.transform.position.y,
                Credit_background4.transform.position.z
            );
        }

        if (Credit_background5.transform.position.x <= -backgroundWidth)
        {
            Credit_background5.transform.position = new Vector3(
                Credit_background4.transform.position.x + (backgroundWidth),
                Credit_background5.transform.position.y,
                Credit_background5.transform.position.z
            );
        }

        if (Credit_background6.transform.position.x <= -backgroundWidth)
        {
            Credit_background6.transform.position = new Vector3(
                Credit_background5.transform.position.x + (backgroundWidth),
                Credit_background6.transform.position.y,
                Credit_background6.transform.position.z
            );
        }
    }
}
