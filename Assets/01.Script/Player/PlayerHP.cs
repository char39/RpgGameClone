using UnityEngine;
using UnityEngine.UI;

public partial class PlayerHP : MonoBehaviour, IPlayerHealth
{
    public Player player;

    void Start()
    {
        SetValue();
    }
    void Update()
    {
        hpimage.fillAmount = hp / maxhp;
        hptext.text = $"{hp}";
        if(hp <= 0&& !GameManger.G_instance.gameover)
        {
            Die();
        }
    }
    void Die()
    {
        GameManger.G_instance.gameover = true;
        player_ani.SetTrigger("Die");
        player_cap.enabled = false;
        rb.isKinematic = true;
    }
    public void SetHealth(float health)
    {
        hp = health;
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;
    }
}
