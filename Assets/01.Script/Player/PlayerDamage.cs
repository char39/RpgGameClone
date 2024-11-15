using System.Collections;
using UnityEngine;

public partial class PlayerDamage : MonoBehaviour
{
    [HideInInspector] public Player player;

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
            player.ani.SetTrigger("Hit");
            HitparticleSystem.Play();
            player.HP.TakeDamage(5);
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