using UnityEngine;

public partial class PlayerAttack : MonoBehaviour
{
    [HideInInspector] public Player player;

    void Start()
    {
        GetValue();
        SetValue();
    }

    void Update()
    {
        Attack();
    }

    private void Attack()
    {
        if (GameManger.instance.gameover) return;

        if (Input.GetMouseButtonDown(0) && !player.Damage.playerHit)
        {
            SwordBox.enabled = true;
            isAttacking = true;
            player.ani.SetBool("AttackCombo", true);
            lastAttackTime = Time.time;
        }

        if (isAttacking)
        {
            if (Time.time - lastAttackTime > comboResetTime)
            {
                isAttacking = false;
                player.ani.SetBool("AttackCombo", true);
            }
        }
        else
        {
            isAttacking = false;
            SwordBox.enabled = false;
            player.ani.SetBool("AttackCombo", false);
        }
    }

    private void TwoAttack()
    {
        TwoAttackPar.Play();
    }
    public void ThreeAttack()
    {
        ThreeAttackPar.Play();
    }
}
