using UnityEngine;

public class BlasterAttack : MonoBehaviour
{
    [SerializeField] float Damage;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            IDamagable damagable = collision.GetComponent<IDamagable>(); 

            damagable.Damage(Damage);
        }
    }
}
