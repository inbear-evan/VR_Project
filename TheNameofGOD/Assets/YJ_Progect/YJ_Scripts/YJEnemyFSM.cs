using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YJEnemyFSM : MonoBehaviour
{
    public enum EnemyState
    {
        Idle,
        Move,
        Attack,
        Return,
        Damaged,
        Jumped,
        Die
    }
    public float attackDistance = 2f;
    public float moveSpeed = 5f;
    CharacterController cc;
    public EnemyState m_State;
    public float findDistance = 8f;
    Transform player;
    float currentTime = 0;
    float attackDelay = 2f;
    public int attackPower = 3;
    Vector3 originPos;
    public float moveDistance = 20f;
    //public int hp = 3;

    public float yVelocity = 0;
    public float flyPower = 10;
    float gravity = -9.8f;
    Vector3 movement;
    Vector3 dir;
    bool isJumped = false;
    protected float jumpTimeDivide = 50f;
    // Start is called before the first frame update
    void Start()
    {
        m_State = EnemyState.Idle;
        player = GameObject.Find("Player").transform;
        cc = GetComponent<CharacterController>();
        //originPos = transform.position;
        //초기에 바닥으로 붙도록 함
    }

    void Idle()
    {
        //if(Vector3.Distance(transform.position,player.position)<findDistance)
        //{
        //m_State = EnemyState.Move;
        //}


        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hitInfo;
        int layer = 1 << LayerMask.NameToLayer("Ground");
        if (Physics.Raycast(ray, out hitInfo, float.MaxValue, layer))
        {
            transform.position = hitInfo.point;
            m_State = EnemyState.Move;
        }

    }

    private void Jumped()
    {
        Vector3 v = dir;
        if (isJumped)
        {
            if (cc.isGrounded)
            {
                m_State = EnemyState.Move;
                yVelocity = 0;
                isJumped = false;
            }
            else
            {
                
                yVelocity += gravity * Time.deltaTime;
                v.y = yVelocity;
                //v.y = 0;
            }
        }
        else
        {
            v.z = flyPower * 2;
            v.y = flyPower * flyPower;
            isJumped = true;
        }
        cc.Move(v * Time.deltaTime);
    }
    void Move()
    {
        //yVelocity += gravity * Time.deltaTime;
        //if (Vector3.Distance(transform.position, originPos) > moveDistance)
        //{
        //    m_State = EnemyState.Return;
        //}

        if (Vector3.Distance(transform.position, player.position) > attackDistance)
        {
            dir = (player.position - transform.position);
            dir.Normalize();
            dir.y = yVelocity;
            //dir.y = gravity;
            cc.Move(dir * moveSpeed * Time.deltaTime);
        }
        else
        {
            m_State = EnemyState.Attack;
            currentTime = attackDelay;
        }
    }
    void Attack()
    {
        if (Vector3.Distance(transform.position, player.position) < attackDistance)
        {
            currentTime += Time.deltaTime;
            if (currentTime > attackDelay)
            {
                if (HpImageUI.instance.totalHp != 0)
                    HpImageUI.instance.OnDamaged(attackPower);
                //player.GetComponent<HpImageUI>().OnDamaged(attackPower);
                //player.GetComponent<kyg_PlayerHP>().CurrentHp -= attackPower;
                //GetComponent<YJEnemy>().OnAttackHit(attackPower);
                currentTime = 0;
            }
        }
        else
        {
            m_State = EnemyState.Move;
            currentTime = 0;
        }
    }
    //void Return()
    //{
    //    if(Vector3.Distance(transform.position,originPos)>0.1f)
    //    {
    //        dir = (originPos - transform.position).normalized;
    //        cc.Move(dir * moveSpeed * Time.deltaTime);
    //    }
    //    else
    //    {
    //        transform.position = originPos;
    //        m_State = EnemyState.Idle;
    //    }    
    //}
    //public void hitEnemy(int hitPower)
    //{
    //    if(m_State == EnemyState.Damaged && m_State == EnemyState.Die && m_State==EnemyState.Return)
    //    { return; }
    //    hp -= hitPower;
    //    if(hp>0)
    //    {
    //        m_State = EnemyState.Damaged;
    //        Damaged();
    //    }
    //    else 
    //    {
    //        m_State = EnemyState.Die;
    //        Die();
    //    }
    //}
    void Damaged()
    {
        StartCoroutine(DamageProcess());
    }
    IEnumerator DamageProcess()
    {
        yield return new WaitForSeconds(0.5f);
        m_State = EnemyState.Move;
    }
    void Die()
    {
        StopAllCoroutines();
        StartCoroutine(DieProcess());
    }
    IEnumerator DieProcess()
    {
        cc.enabled = false;
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        switch (m_State)
        {
            case EnemyState.Idle:
                Idle();
                break;
            case EnemyState.Move:
                Move();
                break;
            case EnemyState.Attack:
                Attack();
                break;
            //case EnemyState.Return: //이건 필요 없을 듯...
            //    //Return();
            //    break;
            case EnemyState.Damaged:
                Damaged();
                break;
            case EnemyState.Jumped:
                Jumped();
                break;
            case EnemyState.Die:
                Die();
                break;
        }
    }

}
