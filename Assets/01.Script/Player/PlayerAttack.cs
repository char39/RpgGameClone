using UnityEngine;

public partial class PlayerAttack : MonoBehaviour
{
    public Player player;

    void Start()
    {
        GetValue();
        SetValue();
    }

    void Update()
    {
        if (GameManger.G_instance.gameover) return;
        if (Input.GetMouseButtonDown(0) && !playerDamage.playerHit)
        {
            SwordBox.enabled = true;
            isAttacking = true;
            Player_Animator.SetBool("AttackCombo", true);
            lastAttackTime = Time.time;
        }
        if (isAttacking)
        {
            if (Time.time - lastAttackTime > comboResetTime)
            {
                isAttacking = false;
                Player_Animator.SetBool("AttackCombo", true);
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
