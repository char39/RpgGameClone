using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour,IPlayerHealth
{
  
    Image hpimage;
    Text hptext;
    Animator player_ani;
    CapsuleCollider player_cap;
    Rigidbody rb;
    /// <summary>
    /// º¯¼ö
    /// </summary>
    float hp;
    float maxhp = 100f;
    void Start()
    {
        SetHealth(maxhp);
        hpimage = transform.GetChild(7).GetChild(1).GetComponent<Image>();
        hptext = transform.GetChild(7).GetChild(2).GetComponent<Text>();
        player_ani = GetComponent<Animator>();
        player_cap = GetComponent<CapsuleCollider>();
        rb = GetComponent<Rigidbody>();
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
