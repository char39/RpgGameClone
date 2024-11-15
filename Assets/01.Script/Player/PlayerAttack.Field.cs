using UnityEngine;

public partial class PlayerAttack : MonoBehaviour
{
    [SerializeField] Animator Player_Animator;
    [SerializeField] ParticleSystem TwoAttackPar;
    [SerializeField] ParticleSystem ThreeAttackPar;
    [SerializeField] BoxCollider SwordBox;
    PlayerDamage playerDamage;

    public bool isAttacking = false;
    private float comboResetTime = 0.3f;
    private float lastAttackTime = 0f;

    private void GetValue()
    {
        playerDamage = GetComponent<PlayerDamage>();
        SwordBox = transform.GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(0).GetChild(1).GetChild(1).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<BoxCollider>();
        Player_Animator = GetComponent<Animator>();
        TwoAttackPar = transform.GetChild(2).GetComponent<ParticleSystem>();
        ThreeAttackPar = transform.GetChild(3).GetComponent<ParticleSystem>();
    }

    private void SetValue()
    {
        SwordBox.enabled = false;
        TwoAttackPar.Stop();
        ThreeAttackPar.Stop();
    }
}
