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
    //    // �÷��̾ Hit�ϴ� �����̴�.
    //    // ���� �÷��̾ ���ݻ����Ÿ� �ȿ� �ִٸ�
    //    float distance = Vector3.Distance(transform.position, target.transform.position);
    //    if (distance <= agent.stoppingDistance)
    //    {
    //        // Hit �ϰ�ʹ�.
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
        //    // ���� ī��Ʈ�� 0���� �ʱ�ȭ�ؾ��Ѵ�.
        //    flyCount = 0;
        //    yVelocity = 0;
        //}
        //else
        //{
        //    // 1. yVelocity�� �߷��� ������ �ް�ʹ�.
        //    yVelocity += gravity * Time.deltaTime;
        //}
        //// 2. ���� (����ī��Ʈ < �ִ�����ī��Ʈ) �׸��� ������ ���� ���¶��
        //if (flyCount < maxFlyCount && Input.GetButtonDown("Jump"))
        //{
        //    // 3. yVelocity�� flyPower�� ������ �����ϰ�ʹ�.
        //    yVelocity = flyPower;
        //    // ����ī��Ʈ�� 1�� �����ؾ��Ѵ�.
        //    flyCount++;
        //}

    }
}
