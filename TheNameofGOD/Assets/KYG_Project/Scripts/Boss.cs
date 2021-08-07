using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Boss : MonoBehaviour
{
    public float speed = 7.5f;
    Vector3 dir;
  //  NavMeshAgent BossAgent;
    public float SeeDistance = 25;
    public float AttackDistance = 4;
    public Animator anim;
    void Start()
    {
        B_State = BossState.Idle;
     //   BossAgent = GetComponent<NavMeshAgent>();
    }


    public enum BossState
        {
        Idle,
        Run,
        Attack,
        Die
        }

    public BossState B_State;

    private void Update()
    {
        switch (B_State)
        {
            case BossState.Idle:
                Idle();
                break;
            case BossState.Run:
                Run();
                break;
            case BossState.Attack:
                Attack();
                break;

            //case EnemyState.Damaged:
            //    Damaged();
            //    break;
            //case EnemyState.Jumped:
            //    Jumped();
            //    break;
            case BossState.Die:
                Die();
                break;
        }
    }

    private void Idle()
    {
    GameObject target = GameObject.Find("Player");
        // 일정거리 내로 들어오면 Run으로 상태변환 하고 싶다.
        float Pdistance = Vector3.Distance(transform.position, target.transform.position);
        if (Pdistance <= SeeDistance)
        {
            B_State = BossState.Run;
            anim.SetTrigger("Run");
        }
    }
    private void Run()
    {
    GameObject target = GameObject.Find("Player");
        float Pdistance = Vector3.Distance(transform.position, target.transform.position);
        dir = target.transform.position - transform.position;
        dir.Normalize();
        transform.position = transform.position + dir * speed * Time.deltaTime;
        if(Pdistance <= AttackDistance)
        {
            B_State = BossState.Attack;
            anim.SetTrigger("Attack");
        }
        
    }

    private void Attack()
    {

    }

    private void Die()
    {

    }










}



//public class Boss : YJEnemyFSM
//{
//    public float speed = 7.5f;
//    int prevEnemyHP;
//    public float BossYVelocity = 0;
//    [SerializeField]
//    float BossflyPower = 7;
//    [SerializeField]
//    float gravity = -9.8f;
//    CharacterController cc;
//    public int BossHP = 300;
//    public float fastSpeed = 10;
//    public EnemyState BossState;
//    // Start is called before the first frame update
//    void Start()
//    {
//   //     cc = GetComponent<CharacterController>();
//        BossState = EnemyState.Idle;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        switch (m_State)
//        {
//            case EnemyState.Idle:
//                Idle();
//                break;
//            case EnemyState.Move:
//                Move();
//                break;
//            case EnemyState.Attack:
//                Attack();
//                break;
//            //case EnemyState.Return: //이건 필요 없을 듯...
//            //    //Return();
//            //    break;
//            case EnemyState.Damaged:
//                Damaged();
//                break;
//            case EnemyState.Jumped:
//                Jumped();
//                break;
//            case EnemyState.Die:
//                Die();
//                break;
//        }
//    }
//    public int currentEnemyHP = 300;

//    internal void DoDamage(int damage)
//    {
//        currentEnemyHP -= damage;
//        Debug.Log("Enemy HP : " + currentEnemyHP);
//        if (prevEnemyHP != currentEnemyHP)
//        {
//            yVelocity = 0;
//        }
//        // 만약 HP가 0이하라면
//        if (currentEnemyHP <= 0)
//        {
//            // 적이 죽는 상태
//            m_State = EnemyState.Die;
//            Destroy(gameObject);
//        }
//        prevEnemyHP = currentEnemyHP;
//    }
//}
