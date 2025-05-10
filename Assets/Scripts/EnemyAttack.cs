using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class EnemyAttack : MonoBehaviour
{
    public GameObject enemyBullet;
    public float fireRate = 1f;

    private void Start()
    {
        InvokeRepeating("Fire" , 0f, fireRate);
    }

    void Fire()
    {
        Instantiate(enemyBullet, transform.position, Quaternion.identity);
    }


}
