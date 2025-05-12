using System.Collections;
using UnityEngine;

public class Speech1 : MonoBehaviour
{
    // 대화창
    [SerializeField] GameObject speechBubble;
    [SerializeField] Transform speechPivot; // 대화창이 생성될 위치
    // 대사 확인 bool 변수
    bool H_check1 = false;
    bool H_check2 = false;
    bool H_check3 = false;
    BossHealth bossHealth;
    void Start()
    {
        bossHealth = GetComponent<BossHealth>();
    }
    
    void Update()
    {
        float life = bossHealth.CurrentLife/bossHealth.InitLife; // 보스 체력 비율

        if(life <= 0.99f && !H_check1) //  99% 이하
        {
            speechBubble.SetActive(true);
            H_check1 = true;   
        }
        else if(life <= 0.75f && !H_check2) //  75% 이하
        {
            H_check2 = true;
        }
        else if(life <= 0.5f && !H_check3) //  50% 이하
        {
            H_check3 = true;
        }
    }
}
