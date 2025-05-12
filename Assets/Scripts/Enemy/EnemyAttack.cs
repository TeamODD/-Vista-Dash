using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class EnemyAttack : MonoBehaviour
{
    public GameObject enemyBullet1;
    public GameObject enemyBullet2;
    public GameObject enemyBullet3;
    public ScrollingObject scrollingObject;
    public float fireRate = 1f;

    private void Start()
    {
        scrollingObject = FindAnyObjectByType<ScrollingObject>();
        Invoke("Fire", fireRate);
    }

    void Fire()
    {
        Instantiate(enemyBullet1, transform.position, Quaternion.identity);
        Instantiate(enemyBullet2, transform.position, Quaternion.identity);
        Instantiate(enemyBullet3, transform.position, Quaternion.identity);
        Debug.Log("위치" + scrollingObject.direction + "sssssssssssssssssssssssssssssssss");
    }
}
