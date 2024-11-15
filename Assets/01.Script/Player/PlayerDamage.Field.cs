using UnityEngine;

public partial class PlayerDamage : MonoBehaviour
{
    ParticleSystem HitparticleSystem;
    Animator animator;
    PlayerHP playerhp;
    public bool playerHit;

    private void GetValue()
    {
        animator = GetComponent<Animator>();
        HitparticleSystem = transform.GetChild(4).GetComponent<ParticleSystem>();
        playerhp = GetComponent<PlayerHP>();
    }

    private void SetValue()
    {
        HitparticleSystem.Stop();
    }
}