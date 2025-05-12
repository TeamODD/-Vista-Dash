using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class EnemyAttack3 : MonoBehaviour
{
    public GameObject enemyBullet;
    public ScrollingObject scrollingObject;
    public float fireRate = 1f;

    Vector2 basePos;
    private void Start()
    {
        basePos = transform.position;
        scrollingObject = FindAnyObjectByType<ScrollingObject>();
        Invoke("Fire3", fireRate);
        Invoke("Fire4" , fireRate+0.3f);
    }


    void Fire3()
    {
        Instantiate(enemyBullet, basePos + new Vector2(-0.5f,0), Quaternion.identity);
    }
    void Fire4()
    {
        Instantiate(enemyBullet, basePos + new Vector2(0.5f,0), Quaternion.identity);
        Debug.Log("위치" + scrollingObject.direction + "sssssssssssssssssssssssssssssssss");
    }
}