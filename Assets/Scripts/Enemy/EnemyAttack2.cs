using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class EnemyAttack2 : MonoBehaviour
{
    public GameObject enemyBullet;
    public ScrollingObject scrollingObject;
    public float fireRate = 1f;

    Vector2 basePos;
    private void Start()
    {
        basePos = transform.position;
        scrollingObject = FindAnyObjectByType<ScrollingObject>();
        Invoke("Fire2", fireRate);
    }

    void Fire2()
    {
        Instantiate(enemyBullet, basePos + new Vector2(0,0.5f), Quaternion.identity);
        Instantiate(enemyBullet, basePos, Quaternion.identity);
        Instantiate(enemyBullet, basePos + new Vector2(0,-0.5f), Quaternion.identity);
        Debug.Log("위치" + scrollingObject.direction + "sssssssssssssssssssssssssssssssss");
    }
}