using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamage : MonoBehaviour
{
    ParticleSystem HitparticleSystem;
    Animator animator;
    PlayerHP playerhp;
    public bool playerHit;
    void Start()
    {
        animator = GetComponent<Animator>();
        HitparticleSystem = transform.GetChild(4).GetComponent<ParticleSystem>();
        HitparticleSystem.Stop();
        playerhp = GetComponent<PlayerHP>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyAttackBox"))
        {
            playerHit = true;
            StartCoroutine(ReturnHit());
            animator.SetTrigger("Hit");
            HitparticleSystem.Play();
            playerhp.TakeDamage(5);
        }
    }
    IEnumerator ReturnHit()
    {
        yield return new WaitForSeconds(2f);
        playerHit = false;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyAttackBox"))
        {
            playerHit = false;
            HitparticleSystem.Stop();
        }
    }

    
}
