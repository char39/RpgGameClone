using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerHP HP;
    public PlayerMove Move;
    public PlayerRotation Rotation;
    public PlayerDamage Damage;
    public PlayerAttack Attack;
    public PlayerSkills Skills;

    void Awake()
    {
        TryGetComponent(out HP);
        TryGetComponent(out Move);
        TryGetComponent(out Rotation);
        TryGetComponent(out Damage);
        TryGetComponent(out Attack);
        TryGetComponent(out Skills);

        HP.player = this;
        Move.player = this;
        Rotation.player = this;
        Damage.player = this;
        Attack.player = this;
        Skills.player = this;
    }




}
