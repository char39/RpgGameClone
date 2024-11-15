using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkills : MonoBehaviour
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
    [SerializeField] PlayerAttack attack;

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

    void Start()
    {
        attack = GetComponent<PlayerAttack>();
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

        SwordPar.Stop();
        SkillUiText.enabled = false;
        TwoSkillUiText.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && Time.time >= twoskilltimerover && !isSkillings && !isTwoskilling)
        {
            TwoSkillUiimage.fillAmount = 0;
            TwoSkillUiText.enabled = true;
            StartCoroutine(Skilltwo());
            StartCoroutine(UpdateSkillTwoUi());
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && Time.time >= oneskilltimerover && !isSkillings)
        {
            SkillUiimage.fillAmount = 0;
            SkillUiText.enabled = true;
            StartCoroutine(Skillone());
            StartCoroutine(UpdateSkillUi());
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            StartCoroutine(Ultimate());
        }
    }

    IEnumerator Skillone()
    {
        isSkillings = true;
        isOneskilling = true;
        oneskilltimerover = Time.time + oneskillTimer;
        Player_ani.SetTrigger("Skillone");
        yield return new WaitForSeconds(0.5f);
        float distanceLevel = 10f;
        Vector3 skilldistance = transform.position + transform.forward * distanceLevel;
        var skillone = Instantiate(skillOne, skilldistance, transform.rotation);
        SwordPar.Stop();
        yield return new WaitForSeconds(0.5f);
        isOneskilling = false;
        isSkillings = false;
    }

    IEnumerator Skilltwo()
    {
        isTwoskilling = true;
        isSkillings = true;
        twoskilltimerover = twoskilltimerover + twoskillTimer;
        Player_ani.SetTrigger("Skilltwo");
        yield return new WaitForSeconds(0.5f);
        float pluesYpos = 1.5f;
        Vector3 skillUppos = transform.position + transform.up * pluesYpos;
        var skilltwo = Instantiate(skillTwo, skillUppos, transform.rotation);
        isSkillings = false;
        yield return new WaitForSeconds(2f);
        Destroy(skilltwo);
    }

    IEnumerator Ultimate()
    {
        isSkillings = true;
        ultimatering = true;
        Player_ani.SetTrigger("Ultimate");

        yield return new WaitForSeconds(1.14f); // �ִϸ��̼� ���

        Vector3 skillup = transform.position+ transform.up * 1.5f;
        // �÷��̾��� ���� ������ ������� ��ȯ ��ġ ���
        var snowWould = Instantiate(ultimatePar, transform.position, ultimatePar.transform.rotation); // �÷��̾� �������� ȸ�� ����
        isSkillings = false;

        yield return new WaitForSeconds(2.8f); // �ִϸ��̼� ���
        for (int i = 0; i < maxSkulls; i++)
        {
            // ���� ���� ����
            float randomX = Random.Range(-1f, 1f); // X�� ����
            float randomZ = Random.Range(-1f, 1f); // Z�� ����
            Vector3 randomDirection = new Vector3(randomX, 0, randomZ).normalized; // ���� ���� ���� ���� �� ����ȭ

            // ��ȯ ��ġ ���
            Vector3 skullSpawnPosition = snowWould.transform.position + randomDirection * 2; // ���� �������� ��ȯ ��ġ ����

            GameObject skull = Instantiate(ultimateSK, skullSpawnPosition, Quaternion.identity); // ���� �������� ���� ��ȯ
            summonedSkulls.Add(skull);
            yield return new WaitForSeconds(2f); // 2�� ��� �� ���� ���� ��ȯ
        }

        yield return new WaitForSeconds(21f); // ��ȯ�� ������ 5�� ���� ����
        foreach (var skull in summonedSkulls)
        {
            Destroy(skull); // ���� ����
        }
        summonedSkulls.Clear(); // ����Ʈ �ʱ�ȭ
        Destroy(snowWould);
    }


    IEnumerator UpdateSkillUi()
    {
        float elapsedTime = 0f;
        SkillUiText.text = $"{(int)elapsedTime}";
        while (elapsedTime < oneskillTimer)
        {
            float remainingTime = oneskillTimer - elapsedTime;
            SkillUiText.text = $"{(int)remainingTime}";
            SkillUiimage.fillAmount = elapsedTime / oneskillTimer;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        SkillUiimage.fillAmount = 1;
        SkillUiText.enabled = false;
    }

    IEnumerator UpdateSkillTwoUi()
    {
        float elapsedTime = 0f;
        TwoSkillUiText.text = $"{(int)elapsedTime}";
        while (elapsedTime < twoskillTimer)
        {
            float remainingTime = twoskillTimer - elapsedTime;
            TwoSkillUiText.text = $"{(int)remainingTime}";
            TwoSkillUiimage.fillAmount = elapsedTime / twoskillTimer;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        TwoSkillUiimage.fillAmount = 1;
        TwoSkillUiText.enabled = false;
        isTwoskilling = false;
    }

    void SwordSkillEffect()
    {
        SwordPar.Play();
    }
}
