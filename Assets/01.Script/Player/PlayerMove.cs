using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Transform Player_pos;
    Animator Player_Animator;
    Vector3 PlayerMoveMent;
    PlayerAttack playerAttack;
    PlayerHP playerHP;
    PlayerSkills playerSkills;
    float Player_WalkSpeed = 5f;
    
    
    void Start()
    {

        Player_pos = transform;
        playerHP = GetComponent<PlayerHP>();
        Player_Animator = GetComponent<Animator>();
        playerAttack = GetComponent<PlayerAttack>();
        playerSkills = GetComponent<PlayerSkills>();
    }
    void Update()
    {
        if (playerAttack.isAttacking ==false && !GameManger.G_instance.gameover&&!playerSkills.isSkillings)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            PlayerMoveMent = new Vector3(horizontal, 0, vertical).normalized;

            Player_Animator.SetFloat("SpeedX", PlayerMoveMent.x);
            Player_Animator.SetFloat("SpeedY", PlayerMoveMent.z);

            Player_pos.Translate(PlayerMoveMent * Player_WalkSpeed * Time.deltaTime);
        }
       
    }
}
