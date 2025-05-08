using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    public GameObject background;
    //public GameObject background2;
    private float backgroundWidth;

    void Start()
    {
        SpriteRenderer sr = background.GetComponent<SpriteRenderer>();
        backgroundWidth = sr. bounds.size.x;
    }

    void Update()
    {
        if(background.transform.position.x <= -backgroundWidth)
        {
            background.transform.position = new Vector2(
                background.transform.position.x + backgroundWidth*2, 
                background.transform.position.y);
        }

    }
}
