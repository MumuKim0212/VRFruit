using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float curHealth; //* 현재 체력
    public float maxHealth = 100f; //* 최대 체력
    AudioSource source;
    public AudioClip deadAudioClip;
    public AudioClip damageAudioClip;

    [Header("Text")]
    public Text bestScoreText;          // 점수를 출력할 UI 텍스트
    public GameObject gameoverUI;       // 게임 오버시 활성화 할 UI 게임 오브젝트
    private float bestScore;
    public bool isGameover = false;     // 게임 오버 상태

    private void Start()
    {
        SetHp(100);
        CheckHp();
        source = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (isGameover && Input.GetMouseButtonDown(0))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SetHp(float amount) //*Hp설정
    {
        maxHealth = amount;
        curHealth = maxHealth;
    }
    public Slider HpBarSlider;

    public void CheckHp() //*HP 갱신
    {
        if (HpBarSlider != null)
            HpBarSlider.value = curHealth / maxHealth;
    }

    public void Damage(float damage) //* 데미지 받는 함수
    {
        source.PlayOneShot(damageAudioClip);
        if (maxHealth == 0 || curHealth <= 0) //* 이미 체력 0이하면 패스
            return;
        curHealth -= damage;
        CheckHp(); //* 체력 갱신
        if (curHealth <= 0)
        {
            gameoverUI.SetActive(true);
            OnPlayerDead();
        }
    }
    public void OnPlayerDead()
    {
        bestScore = PlayerPrefs.GetFloat("BestScore", 0);
        isGameover = true;
        source.PlayOneShot(deadAudioClip);

        if (Weapon.score > bestScore)
        {
            bestScore = Weapon.score;
            PlayerPrefs.SetFloat("BestScore", bestScore);
        }
        bestScoreText.text = "BestScore : " + bestScore;
        gameoverUI.SetActive(true);
    }
}
