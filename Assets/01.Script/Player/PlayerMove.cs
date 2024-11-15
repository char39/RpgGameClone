using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Player player;

    Transform Player_pos;
    Animator Player_Animator;
    Vector3 PlayerMoveMent;
    PlayerAttack playerAttack;
    PlayerSkills playerSkills;
    float Player_WalkSpeed = 5f;
    
    
    void Start()
    {

        Player_pos = transform;
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
