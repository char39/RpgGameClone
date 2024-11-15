using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]Animator Player_Animator;

    [SerializeField] ParticleSystem TwoAttackPar;
    [SerializeField] ParticleSystem ThreeAttackPar;
    [SerializeField] BoxCollider SwordBox;
    PlayerHP playerHP;
    PlayerDamage playerDamage;


    public bool isAttacking = false; // 공격 상태
    private float comboResetTime = 0.3f; // 콤보 리셋 시간
    private float lastAttackTime = 0f; // 마지막 공격 시간
    

    void Start()
    {
        playerDamage = GetComponent<PlayerDamage>();
        playerHP = GetComponent<PlayerHP>();
        SwordBox = transform.GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(0).GetChild(1).GetChild(1).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<BoxCollider>();
        Player_Animator = GetComponent<Animator>();
        TwoAttackPar = transform.GetChild(2).GetComponent<ParticleSystem>();  
        ThreeAttackPar = transform.GetChild(3).GetComponent<ParticleSystem>();
        SwordBox.enabled = false;
        TwoAttackPar.Stop();
        ThreeAttackPar.Stop();
    }

    void Update()
    {
        if (GameManger.G_instance.gameover) return;
        if (Input.GetMouseButtonDown(0)&& !playerDamage.playerHit)
        {
            SwordBox.enabled = true;
            isAttacking = true; // 연타 시작
            Player_Animator.SetBool("AttackCombo", true); // 공격 애니메이션 파라미터 설정
            lastAttackTime = Time.time; // 마지막 공격 시간 갱신
        }
        if (isAttacking)
        {
            if (Time.time - lastAttackTime > comboResetTime)
            {
                isAttacking = false; // 공격 상태 리셋
                Player_Animator.SetBool("AttackCombo", true); // 애니메이션 파라미터도 false로 설정
            }
        }
        else
        {
            isAttacking = false;
            SwordBox.enabled = false;
            Player_Animator.SetBool("AttackCombo", false);
        }
    }
 

    void TwoAttack()
    {
        TwoAttackPar.Play();
    }
    public void ThreeAttack()
    {
        ThreeAttackPar.Play();
    }
}
