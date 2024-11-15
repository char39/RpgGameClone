using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public partial class PlayerSkills : MonoBehaviour
{
    [SerializeField] GameObject skillOne;
    [SerializeField] GameObject skillTwo;
    [SerializeField] GameObject ultimatePar;
    [SerializeField] GameObject ultimateSK;

    [SerializeField] Animator Player_ani;

    [SerializeField] Image SkillUiimage;
    [SerializeField] Image TwoSkillUiimage;

    [SerializeField] Text SkillUiText;
    [SerializeField] Text TwoSkillUiText;

    [SerializeField] ParticleSystem SwordPar;

    [SerializeField] List<GameObject> Sk_List;
    float oneskillTimer = 20f;
    float twoskillTimer = 5f;
    float twoskilltimerover;
    float oneskilltimerover;
    public bool isOneskilling;
    public bool isTwoskilling;
    public bool ultimatering;
    public bool isSkillings;

    private List<GameObject> summonedSkulls = new List<GameObject>();
    private const int maxSkulls = 3;

    private void GetValue()
    {
        skillOne = Resources.Load<GameObject>("Skill/SkillOne");
        skillTwo = Resources.Load<GameObject>("Skill/Sleash");
        ultimatePar = Resources.Load<GameObject>("Skill/SkillThree");
        ultimateSK = Resources.Load<GameObject>("Skill/Skeleton");
        Player_ani = GetComponent<Animator>();
        SkillUiimage = transform.GetChild(7).GetChild(3).GetChild(0).GetChild(1).GetComponent<Image>();
        SkillUiText = transform.GetChild(7).GetChild(3).GetChild(0).GetChild(2).GetComponent<Text>();
        TwoSkillUiimage = transform.GetChild(7).GetChild(3).GetChild(1).GetChild(1).GetComponent<Image>();
        TwoSkillUiText = transform.GetChild(7).GetChild(3).GetChild(1).GetChild(2).GetComponent<Text>();
        SwordPar = transform.GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetChild(0).GetChild(1).GetChild(1).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<ParticleSystem>();

    }

    private void SetValue()
    {
        SwordPar.Stop();
        SkillUiText.enabled = false;
        TwoSkillUiText.enabled = false;
    }
}