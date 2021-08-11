using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public float moveDistance = 20f;
    //public int hp = 3;

    public float yVelocity = 0;
    public float flyPower = 10;
    float gravity = -9.8f;
    Vector3 dir;
    bool isJumped = false;
    protected float jumpTimeDivide = 50f;

    Animator ani;
    public GameObject shieldParticle;
    //public Slider hp;
    Material mat;
    float alphaValue = 0;
    public bool jumpAttack = false;
    // Start is called before the first frame update
    void Start()
    {
        //m_State = EnemyState.Idle;

        mat = transform.GetChild(0).GetChild(0).GetComponent<Renderer>().material;
        mat.SetFloat("_DissolveAmount", 0);
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

    }

    public void Jumped()
    {
        print("UPPER State");
        //m_State = EnemyState.Jumped;
        //Vector3 v;
        if (isJumped)
        {
            if (cc.isGrounded)
            {
                if (m_State != EnemyState.Die)
                {
                    m_State = EnemyState.Move;
                    ani.SetTrigger("Walk");
                    yVelocity = gravity;
                    //cc.Move(dir * moveSpeed * Time.deltaTime);
                    isJumped = false;
                }
            }
            else
            {
                yVelocity += gravity * Time.deltaTime * 2;
                //v.y = yVelocity;
            }

            cc.Move(new Vector3(0, 1, 0) * yVelocity * Time.deltaTime);
        }
        else
        {
            yVelocity = flyPower;
            isJumped = true;
            cc.Move(new Vector3(0, 1, -transform.forward.z/2) * yVelocity);
        }
        //cc.Move(new Vector3(0, 1, 0) * yVelocity * Time.deltaTime);
    }
    void Move()
    {
        if (prevState == EnemyState.Hit)
        {
            StopCoroutine(DamageProcess());
        }
        if (Vector3.Distance(transform.position, player.position) > attackDistance || prevState == EnemyState.Jumped)
        {
            dir = (player.position - transform.position);
            dir.Normalize();
            dir.y = yVelocity;
            cc.Move(dir * moveSpeed * Time.deltaTime);
            dir.y = 0;
            transform.forward = dir.normalized;
        }
        else
        {
            ani.ResetTrigger("Walk");
            m_State = EnemyState.Attack;
            ani.SetTrigger("Attack");
            ani.Play("Attack");
            currentTime = attackDelay;
        }
    }
    public void Attack()
    {
        //ani.ResetTrigger("Attack");
        if (Vector3.Distance(transform.position, player.position) < attackDistance)
        {
            //ani.SetTrigger("Attack");
            //ani.Play("Attack");
            bool shieldChk = false;
            int colsNum = 0;
            currentTime += Time.deltaTime;
            if (currentTime > attackDelay)
            {
                Collider[] cols = Physics.OverlapSphere(transform.position, 5);
                for (int i = 0; i < cols.Length; i++)
                {
                    if (cols[i].gameObject.name.Contains("Shield"))
                    {
                        shieldChk = true;
                        colsNum = i;
                    }
                }

                if (!shieldChk)
                {
                    if (HpImageUI.instance.totalHp != 0)
                        HpImageUI.instance.OnDamaged(attackPower);
                }
                else
                {
                    GameObject shEffect = Instantiate(shieldParticle);
                    shEffect.transform.position = cols[colsNum].transform.position;
                    shEffect.transform.forward = cols[colsNum].transform.forward;
                }
                //player.GetComponent<HpImageUI>().OnDamaged(attackPower);
                //player.GetComponent<kyg_PlayerHP>().CurrentHp -= attackPower;
                //GetComponent<YJEnemy>().OnAttackHit(attackPower);
                currentTime = 0;
                m_State = EnemyState.Move;
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
        m_State = EnemyState.Move;
        //ani.SetTrigger("Walk");
        StartCoroutine(DamageProcess());
    }
    IEnumerator DamageProcess()
    {
        yield return new WaitForSeconds(1f);
        ani.ResetTrigger("Hit");
        ani.SetTrigger("Walk");
        m_State = EnemyState.Move;
    }
    public void Die()
    {
        //m_State = EnemyState.Die;
        //ani.SetTrigger("Die");
        //ani.Play("Die");

        mat.SetFloat("_DissolveAmount", alphaValue);
        if (alphaValue >= 0.95)
            Destroy(gameObject);
        else
            alphaValue += Time.deltaTime;
        //m_State = EnemyState.Idle;
        //StopAllCoroutines();
        //Destroy(gameObject, 3);

        //charaterMat.SetFloat("_DissolveAmount", Mathf.Sin(Time.time) / 2 + 0.5f);
        //StartCoroutine(DieProcess());
    }

    IEnumerator DieProcess()
    {
        cc.enabled = false;
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
    public bool JumpChange(bool upperAttack)
    {
        if (upperAttack)
        {
            m_State = EnemyState.Jumped;
            print("Update Upper State");
            upperAttack = false;
        }
        return upperAttack;
    }
    EnemyState prevState;
    // Update is called once per frame
    void Update()
    {
        if (jumpAttack || prevState == EnemyState.Jumped)
        {
            //kyg_Sword.instance.upperAttack = false;
            m_State = EnemyState.Jumped;
            jumpAttack = false;
        }
        if (m_State == EnemyState.Die) m_State = EnemyState.Die;
        print("Current State : " + m_State);

        switch (m_State)
        {
            case EnemyState.Idle: Idle(); break;
            case EnemyState.Move: Move(); break;
            case EnemyState.Attack:
                //Attack();
                break;
            case EnemyState.Hit: Damaged(); break;
            case EnemyState.Jumped: Jumped(); break;
            case EnemyState.Die:
                alphaValue += Time.deltaTime;
                Die(); 
                break;
        }
        prevState = m_State;
    }

}
