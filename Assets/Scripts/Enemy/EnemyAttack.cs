using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class EnemyAttack : MonoBehaviour
{
    public GameObject enemyBullet;
    public ScrollingObject scrollingObject;
    public float fireRate = 1f;

    private void Start()
    {
        scrollingObject = FindAnyObjectByType<ScrollingObject>();
        Invoke("Fire", fireRate);
    }

    void Fire()
    {
        Instantiate(enemyBullet, transform.position, Quaternion.identity);
        Debug.Log("위치" + scrollingObject.direction + "sssssssssssssssssssssssssssssssss");
    }
}
