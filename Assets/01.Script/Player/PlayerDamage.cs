using System.Collections;
using UnityEngine;

public partial class PlayerDamage : MonoBehaviour
{
    public Player player;

    void Start()
    {
        GetValue();
        SetValue();
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
