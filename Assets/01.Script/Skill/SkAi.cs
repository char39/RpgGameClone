using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkAi : MonoBehaviour
{
    enum State { Idle, Move, Attack, Dead, NotEnemy }
    State currentState = State.Idle;

    NavMeshAgent Sk_agent;
    BoxCollider Sword;
    [SerializeField] Transform enemypos;
    Transform Playerpos;
    Animator sk_animator;

    float attackdistance = 1f;
    float finddistance = 8f;
    float timer = 0f;
    float DeadTime = 20f;
    string Enemytag = "Enemy";
    string Playertag = "Player";

    void Awake()
    {
        Sk_agent = GetComponent<NavMeshAgent>();
        Sword = transform.GetChild(0).GetChild(2).GetComponent<BoxCollider>();
        Playerpos = GameObject.Find(Playertag).transform;
        sk_animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        Sk_agent.speed = 2;
        Sk_agent.isStopped = false;
        currentState = State.Idle; // 상태 초기화
        timer = 0f; // 타이머 초기화
        StartCoroutine(StateMachine());
    }

    IEnumerator StateMachine()
    {
        while (true)
        {
            // 타이머 체크
            timer += Time.deltaTime;
            if (timer >= DeadTime && currentState != State.Dead)
            {
                currentState = State.Dead;
                yield return StartCoroutine(Sk_Dead());
                break; // 코루틴 종료
            }

            EnemyFind();

            switch (currentState)
            {
                case State.Move:
                    Move();
                    break;

                case State.Attack:
                    Sk_Attack();
                    break;

                case State.NotEnemy:
                    NotEnemy();
                    break;
            }

            yield return null; // 다음 프레임까지 대기
        }
    }

    private void EnemyFind()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(Enemytag);
        GameObject closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemy;
            }
        }

        if (closestEnemy != null)
        {
            enemypos = closestEnemy.transform;
            var distanceToEnemy = Vector3.Distance(transform.position, enemypos.position);

            if (distanceToEnemy <= attackdistance)
            {
                currentState = State.Attack;
            }
            else if (distanceToEnemy <= finddistance)
            {
                currentState = State.Move;
            }
        }
        else
        {
            currentState = State.NotEnemy; // 적이 없을 경우 상태 전환
        }
    }

    IEnumerator Sk_Dead()
    {
        sk_animator.SetTrigger("Dead");
        Sk_agent.speed = 0;
        Sk_agent.isStopped = true;
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }

    private void Move()
    {
        sk_animator.SetBool("Idle", false);
        sk_animator.SetBool("Find", true);
        sk_animator.SetBool("Attack", false);
        Sk_agent.destination = enemypos.position;
        Sk_agent.isStopped = false;

        // Move 상태에서 적과의 거리 체크
        if (Vector3.Distance(transform.position, enemypos.position) <= attackdistance)
        {
            currentState = State.Attack; // 공격 상태로 전환
        }
    }

    void Sk_Attack()
    {
        sk_animator.SetBool("Idle", false);
        sk_animator.SetBool("Find", false);
        sk_animator.SetBool("Attack", true);
        Sk_agent.isStopped = true;

        // 공격 상태에서 적과의 거리 체크
        if (Vector3.Distance(transform.position, enemypos.position) > attackdistance)
        {
            currentState = State.Move; // 다시 이동 상태로 전환
        }
    }

    void NotEnemy()
    {
        var Playerdistance = Vector3.Distance(transform.position, Playerpos.position);
        if(Playerdistance <= 3)
        {
            sk_animator.SetBool("Idle", true);
            sk_animator.SetBool("Find", false);
            Sk_agent.isStopped=true;
        }
        else if(Playerdistance >= 3)
        {
            sk_animator.SetBool("Idle", false);
            sk_animator.SetBool("Find", true);
            Sk_agent.destination = Playerpos.position;
            Sk_agent.isStopped = false;
        }
       
    }

    void Attackbox()
    {
        Sword.enabled = true;
    }

    void AttackOffbox()
    {
        Sword.enabled = false;
    }
}
