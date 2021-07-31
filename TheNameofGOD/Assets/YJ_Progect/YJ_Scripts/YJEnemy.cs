using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class YJEnemy : MonoBehaviour
{
    public float yVelocity = 0;
    [SerializeField]
    float flyPower = 10;
    [SerializeField]
    float gravity = -9.8f;
    CharacterController cc;

    public float speed = 5;
    public float fastSpeed = 10;
    public EnemyHP enemyHP;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        
    }
    int flyCount = 0;
    public int maxFlyCount = 2;

    NavMeshAgent agent;
    GameObject target;

    //internal void OnAttackHit(int damage)
    //{
    //    // 플레이어를 Hit하는 순간이다.
    //    // 만약 플레이어가 공격사정거리 안에 있다면
    //    float distance = Vector3.Distance(transform.position, target.transform.position);
    //    if (distance <= agent.stoppingDistance)
    //    {
    //        // Hit 하고싶다.
    //        HitManager.instance.Hit(damage);
    //    }
    //}


    // Update is called once per frame
    void Update()
    {
        Vector3 movement = Vector3.zero;
        if (cc.isGrounded)
        {
            
        }
        else
        {
           
        }
       
        //if (cc.isGrounded)
        //{
        //    // 점프 카운트를 0으로 초기화해야한다.
        //    flyCount = 0;
        //    yVelocity = 0;
        //}
        //else
        //{
        //    // 1. yVelocity가 중력의 영향을 받고싶다.
        //    yVelocity += gravity * Time.deltaTime;
        //}
        //// 2. 만약 (점프카운트 < 최대점프카운트) 그리고 데미지 당한 상태라면
        //if (flyCount < maxFlyCount && Input.GetButtonDown("Jump"))
        //{
        //    // 3. yVelocity를 flyPower의 값으로 대입하고싶다.
        //    yVelocity = flyPower;
        //    // 점프카운트를 1씩 증가해야한다.
        //    flyCount++;
        //}

    }
}
