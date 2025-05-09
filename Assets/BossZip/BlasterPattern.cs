using System.Collections;
using UnityEngine;

public class BlasterPattern : MonoBehaviour
{
    [SerializeField] GameObject Blaster; // 블래스터 공격 객체 
    [SerializeField] Transform BlasterPivot; // 블래스터가 생성될 위치
    PlayerMovement playerMovement;
    
    void Start()
    {
        playerMovement = FindAnyObjectByType<PlayerMovement>(); // 플레이어의 위치를 할당하기 위해 참조
        StartCoroutine("blasterRoutine");
    }

    IEnumerator blasterRoutine()
    {
        yield return new WaitForSeconds(1f);

        BlasterFollowingPlayer();
        yield return new WaitForSeconds(1.5f);
        BlasterFollowingPlayer();
        yield return new WaitForSeconds(1.5f);
        BlasterFollowingPlayer();
        yield return new WaitForSeconds(1.5f);
        BlasterFollowingPlayer();
        yield return new WaitForSeconds(1.5f);
        BlasterFollowingPlayer();
        yield return new WaitForSeconds(1.5f);
        BlasterFollowingPlayer();
        yield return new WaitForSeconds(1.5f);
        BlasterFollowingPlayer();
        yield return new WaitForSeconds(1.5f);
        BlasterFollowingPlayer();
        yield return new WaitForSeconds(1.5f);

        defaultBlaster(-4);
        yield return new WaitForSeconds(0.3f);
        defaultBlaster(-3);
        yield return new WaitForSeconds(0.3f);
        defaultBlaster(-2);
        yield return new WaitForSeconds(1.5f);

        defaultBlaster(2);
        yield return new WaitForSeconds(0.3f);
        defaultBlaster(3);
        yield return new WaitForSeconds(0.3f);
        defaultBlaster(4);
        yield return new WaitForSeconds(0.3f);

        yield return new WaitForSeconds(3f);
        StartCoroutine("blasterRoutine"); // 3초 쉬고 무한 반복
    }

    void defaultBlaster(int yAxis) // -5부터 5사이
    {
        Instantiate(Blaster, new Vector3(BlasterPivot.position.x, yAxis, BlasterPivot.position.z), Quaternion.identity);
    }

    void BlasterFollowingPlayer()
    {
        Instantiate(Blaster, new Vector3(BlasterPivot.position.x, playerMovement.transform.position.y, BlasterPivot.position.z), Quaternion.identity);        
    }
}
