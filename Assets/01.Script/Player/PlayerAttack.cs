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


    public bool isAttacking = false; // ���� ����
    private float comboResetTime = 0.3f; // �޺� ���� �ð�
    private float lastAttackTime = 0f; // ������ ���� �ð�
    

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
            isAttacking = true; // ��Ÿ ����
            Player_Animator.SetBool("AttackCombo", true); // ���� �ִϸ��̼� �Ķ���� ����
            lastAttackTime = Time.time; // ������ ���� �ð� ����
        }
        if (isAttacking)
        {
            if (Time.time - lastAttackTime > comboResetTime)
            {
                isAttacking = false; // ���� ���� ����
                Player_Animator.SetBool("AttackCombo", true); // �ִϸ��̼� �Ķ���͵� false�� ����
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
