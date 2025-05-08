using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] float timeSum = 0.3f;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletPoint;
    ScrollingObject scrollingBullet;
    private bool isAttackPressed = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void OnAttack(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            isAttackPressed = true;
        }
        else if(context.canceled)
        {
            isAttackPressed = false;
        }
    }


    // Update is called once per frame
    void Update()
    {
        timeSum += Time.deltaTime;
        if(timeSum >= 0.3f && isAttackPressed == true)
        {
            Fire();
            timeSum = 0f;
        }
    }

    void Fire()
    {
        if(isAttackPressed)
        {
            GameObject bullet = Instantiate(bulletPrefab,bulletPoint.position,bulletPoint.rotation);
        }
    }

    
}
