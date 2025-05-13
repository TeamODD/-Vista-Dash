using System.Collections;
using UnityEngine;

public class BlasterPattern1 : MonoBehaviour, IAttackpattern
{
    [SerializeField] GameObject Blaster; // 블래스터 공격 객체 
    [SerializeField] GameObject errorAtack; // 에러 화면 방해 공격 
    [SerializeField] Transform BlasterPivot; // 블래스터가 생성될 위치
    PlayerMovement playerMovement;
    
    void Start()
    {
        playerMovement = FindAnyObjectByType<PlayerMovement>(); // 플레이어의 위치를 할당하기 위해 참조
        StartCoroutine("blasterRoutine");
    }

    IEnumerator blasterRoutine()
    {
        yield return new WaitForSeconds(3f);

        ErrorAttack();
        yield return new WaitForSeconds(9f);

        defaultBlaster(-5);
        yield return new WaitForSeconds(1f);
        defaultBlaster(-4);
        yield return new WaitForSeconds(1f);
        defaultBlaster(-3);
        yield return new WaitForSeconds(1.5f);

        defaultBlaster(3);
        yield return new WaitForSeconds(1f);
        defaultBlaster(4);
        yield return new WaitForSeconds(1f);
        defaultBlaster(5);

        yield return new WaitForSeconds(3f);
        StartCoroutine("blasterRoutine"); // 3초 쉬고 무한 반복
    }

    void defaultBlaster(int yAxis) // -5부터 5사이
    {
        Instantiate(Blaster, new Vector3(BlasterPivot.position.x, yAxis, BlasterPivot.position.z), Quaternion.identity);
    }

    void randomBlaster()
    {
        int rannum = Random.Range(-5, 6); 

        Instantiate(Blaster, new Vector3(BlasterPivot.position.x, rannum, BlasterPivot.position.z), Quaternion.identity);
    }

    void BlasterFollowingPlayer()
    {
        Instantiate(Blaster, new Vector3(BlasterPivot.position.x, playerMovement.transform.position.y, BlasterPivot.position.z), Quaternion.identity);        
    }

    void ErrorAttack()
    {
        Instantiate(errorAtack, new Vector3(1.7f, 0, 0), Quaternion.identity);
    }
}
