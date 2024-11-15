using UnityEngine;
using UnityEngine.UI;

public partial class PlayerHP : MonoBehaviour
{
    Image hpimage;
    Text hptext;
    Animator player_ani;
    CapsuleCollider player_cap;
    Rigidbody rb;
    float hp;
    float maxhp = 100f;

    private void SetValue()
    {
        SetHealth(maxhp);
        hpimage = transform.GetChild(7).GetChild(1).GetComponent<Image>();
        hptext = transform.GetChild(7).GetChild(2).GetComponent<Text>();
        player_ani = GetComponent<Animator>();
        player_cap = GetComponent<CapsuleCollider>();
        rb = GetComponent<Rigidbody>();
    }
}