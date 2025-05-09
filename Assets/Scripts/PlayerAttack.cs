 using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab; // 총알 프리팹
    [SerializeField] Transform bulletPoint; // 총알 발사 위치
    [SerializeField] float fireRate = 0.3f; // 발사 주기 (초)
    [SerializeField] int bulletCount = 30;

    private bool isAttackPressed = false; // 공격 키가 눌려있는지 상태 추적
    private bool wasAttackPressed = false; // 이전에 공격 키가 눌렸는지 추적
    private float timeSum = 0f; // 마지막 발사 이후 경과 시간

    // InputSystem에서 키 입력을 받는 메서드
    public void OnPressFire()
    {
        isAttackPressed = true;
    }

    public void OnReleaseFire()
    {
        isAttackPressed = false;
    }
    void Fire()
    {
        if(bulletCount >0)
        {
            Debug.Log("총알 발사");
            Instantiate(bulletPrefab, bulletPoint.position, bulletPoint.rotation);
            bulletCount--;
        }
        else
        {   
            Debug.Log("총알 발사 불가");
        }
    }

    void Update()
    {
        if (isAttackPressed)
        {
            timeSum += Time.deltaTime;

            if (timeSum >= fireRate)
            {
                Debug.Log("0.3초마다");
                Fire();
                timeSum = 0f;
            }
        }
    }

}