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
        Hit,
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
 
    Animator ani;
 
    // Start is called before the first frame update
    void Start()
    {

        m_State = EnemyState.Idle;
        player = GameObject.Find("Player").transform;
        cc = GetComponent<CharacterController>();
        ani = transform.GetChild(0).GetComponent<Animator>();
        //originPos = transform.position;
        //초기에 바닥으로 붙도록 함

        for (int i = 0; i < 10000; i++)
        {
            Ray ray = new Ray(transform.position, -transform.up);
            RaycastHit hitInfo;
            int layer = 1 << LayerMask.NameToLayer("Ground");
            if (Physics.Raycast(ray, out hitInfo, float.MaxValue, layer))
            {
                transform.position = hitInfo.point;
                m_State = EnemyState.Move;
                ani.SetTrigger("Walk");
                break;
            }
        }
       
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
            ani.SetTrigger("Walk");
        }
    }

    private void Jumped()
    {
        print("UPPER State");
        Vector3 v = dir;
        if (isJumped)
        {
            if (cc.isGrounded)
            {
                m_State = EnemyState.Move;
                yVelocity = 0;
                isJumped = false;
                Vector3 ccRot = new Vector3(90, 0, 0);
                transform.eulerAngles = ccRot;
            }
            else
            {
                yVelocity += gravity * Time.deltaTime;
                v.y = yVelocity;
                cc.Move(v * Time.deltaTime);
            }
        }
        else
        {
            v.y = flyPower * flyPower;
            isJumped = true;
            cc.Move(v * Time.deltaTime);
            Vector3 ccRot = new Vector3(-90, 0, 0);
            transform.eulerAngles = ccRot;
        }


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
            transform.GetChild(0).transform.forward = new Vector3(0, dir.y, dir.z).normalized;
            cc.Move(dir * moveSpeed * Time.deltaTime);
        }
        else
        {
            m_State = EnemyState.Attack;
            ani.SetTrigger("Attack");
            ani.Play("Attack");
            currentTime = attackDelay;
        }
    }
    public void Attack()
    {
        if (Vector3.Distance(transform.position, player.position) < attackDistance)
        {
            bool shieldChk = false;
            currentTime += Time.deltaTime;
            if (currentTime > attackDelay)
            {
                Collider[] cols = Physics.OverlapSphere(transform.position, 5);
                for (int i = 0; i < cols.Length; i++)
                {
                    if (cols[i].gameObject.name.Contains("Shield"))
                    {
                        shieldChk = true;
                    }
                }

                if (!shieldChk)
                {
                    if (HpImageUI.instance.totalHp != 0)
                        HpImageUI.instance.OnDamaged(attackPower);
                }
                //player.GetComponent<HpImageUI>().OnDamaged(attackPower);
                //player.GetComponent<kyg_PlayerHP>().CurrentHp -= attackPower;
                //GetComponent<YJEnemy>().OnAttackHit(attackPower);
                currentTime = 0;
            }
        }
        else
        {
            ani.SetTrigger("Walk");
            m_State = EnemyState.Move;
            currentTime = 0;
        }
    }
    void Damaged()
    {
        ani.SetTrigger("Hit");
        ani.Play("Hit");
        //m_State = EnemyState.Move;
        StartCoroutine(DamageProcess());
    }
    IEnumerator DamageProcess()
    {
        yield return new WaitForSeconds(1f);
        m_State = EnemyState.Move;
    }
    public void Die()
    {
        ani.SetTrigger("Die");
        ani.Play("Die");
        //StopAllCoroutines();
        Destroy(gameObject, 3);
        //charaterMat.SetFloat("_DissolveAmount", Mathf.Sin(Time.time) / 2 + 0.5f);
        //StartCoroutine(DieProcess());
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
            //case enemystate.idle:
            //    idle();
            //    break;
            case EnemyState.Move:
                Move();
                break;
            case EnemyState.Attack:
                Attack();
                break;
            //case EnemyState.Return: //이건 필요 없을 듯...
            //    //Return();
            //    break;
            case EnemyState.Hit:
                Damaged();
                break;
            case EnemyState.Jumped:
                print("Jumped State in!!");
                Jumped();
                break;
            case EnemyState.Die:
                Die();
                break;
        }
    }

}
