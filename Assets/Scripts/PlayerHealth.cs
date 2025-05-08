 using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, IDamagable, IHealable
{
    [SerializeField] float initHealth; // 체력 초기값 100
    [SerializeField] float maxHealth; // 체력 최대값 100 
    [SerializeField] float CurrentHealth; // 현재 체력 
    [SerializeField] Slider slider;
    void Start()
    {
        CurrentHealth = initHealth;
    }

    void Update()
    {
        updateSlider(); // 체력 게이지 지속적으로 갱신
    }

    public void Damage(float damage) // 데미지를 입는 인터페이스 함수
    {
        Debug.Log(damage+"만큼 피해를 입음");
        CurrentHealth -= damage;

        if(CurrentHealth <= 0) // 체력이 0이하라면 사망처리
        {
            Die(); 
        }
    }

    public void Heal(float heal) // 치유를 하는 인터페이스 함수
    {
        Debug.Log(heal+"만큼 치유");
        CurrentHealth += heal;

        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, 100); // 체력이 100 최대치를 넘지 않게 ( 100이상 힐 불가 )
    }

    private void Die() // 사망 처리
    {
        Debug.Log("사망!!");
        // 사망처리 구현필요
    }

    private void updateSlider() // 현재 체력을 입력받아 체력 게이지를 업데이트.
    {
        slider.value = CurrentHealth;
    }
}