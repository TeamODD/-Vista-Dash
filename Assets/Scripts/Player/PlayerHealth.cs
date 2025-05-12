 using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class PlayerHealth : MonoBehaviour, IDamagable, IHealable
{
    [SerializeField] float initHealth; // 체력 초기값 100
    [SerializeField] float maxHealth; // 체력 최대값 100 
    [SerializeField] float CurrentHealth; // 현재 체력 
    [SerializeField] Slider slider;
    [SerializeField] GameObject damageEffect; // 대미지 이펙트
    Animator hitAnimator;
    // 사운드 컴포넌트와 사운드 클립들
    AudioSource audioSource; // 사운드를 재생 할 오디오 소스 컴포넌트
    [SerializeField] AudioClip damageSound; // 피해를 입었을 때 재생할 사운드 
    [SerializeField] AudioClip healSound; // 체력을 회복할 때 재생할 사운드
    void Start()
    {
        CurrentHealth = initHealth;
        hitAnimator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>(); 
    }

    void Update()
    {
        updateSlider(); // 체력 게이지 지속적으로 갱신
    }

    public void Damage(float damage) // 데미지를 입는 인터페이스 함수
    {
        //damageEffect.SetActive(true); // 대미지 이펙트 활성화
        Debug.Log(damage + "만큼 피해를 입음");
        CurrentHealth -= damage;

        // 대미지 애니메이션 재생과 사운드 재생
        hitAnimator.SetTrigger("Attacked"); 
        audioSource.PlayOneShot(damageSound);

        if (CurrentHealth <= 0) // 체력이 0이하라면 사망처리
        {
            Die();
        }
    }


    public void Heal(float heal) // 치유를 하는 인터페이스 함수
    {
        audioSource.PlayOneShot(healSound);

        Debug.Log(heal+"만큼 치유! : "+CurrentHealth);
        CurrentHealth += heal;

        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, 100); // 체력이 100 최대치를 넘지 않게 ( 100이상 힐 불가 )
    }

    public void Die() // 사망 처리
    {
        Debug.Log("사망!!");
        // 사망처리 구현필요 ( 임시로 씬 재로드 )
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // 현재 씬의 이름을 가져와 다시 호출
    }

    private void updateSlider() // 현재 체력을 입력받아 체력 게이지를 업데이트.
    {
        slider.value = CurrentHealth;
    }
}