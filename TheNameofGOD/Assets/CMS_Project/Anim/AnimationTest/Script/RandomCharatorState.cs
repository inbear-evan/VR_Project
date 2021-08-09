using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCharatorState : MonoBehaviour
{
    #region Variable
    public enum State
    {
        Idle,
        Move,
        Attack,
        Damage,
        Jump,
        Die,
        Exit
    }
    State state;
    public float moveSpeed = 5;
    public Animator animator;
    public GameObject target;
    public float AttackDistance = 1;
    public float searchDistance = 2;
    CharacterController controller;

    float distance;

    //Move State
    int moveStateValue = Animator.StringToHash("Move");
    int moveRandomNums = Animator.StringToHash("RandomMove");
    int moveStateNums;
    bool moveStateCheck = false;
    public int moveStateMaxNums = 3;

    //Attack State
    int attackStateValue = Animator.StringToHash("Attack");

    //Jump State
    int jumpStateValue = Animator.StringToHash("Jump");
    int jumpRandomNums = Animator.StringToHash("RandomJump");
    int jumpStateNums;
    public int jumpStateMaxNums = 3;

    //Damage State
    int damageStateValue = Animator.StringToHash("Damage");
    int damageRandomNums = Animator.StringToHash("RandomDamage");
    int damageStateNums;
    public int damageStateMaxNums = 3;

    //Die State
    int dieStateValue = Animator.StringToHash("Die");
    int dieRandomNums = Animator.StringToHash("RandomDie");
    int dieStateNums;
    public int dieStateMaxNums = 4;
    #endregion Variable
    void Start()
    {
        state = State.Idle;
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        distance = Vector3.Distance(transform.position, target.transform.position);
        state = TestChangeState(state);
        StateChange(state);

        Debug.Log("Target Distance : "+ distance);
    }
    void StateChange(State s)
    {
        Debug.Log("Now State : " + s);
        switch (s)
        {
            case State.Idle: Idle(); break;
            case State.Move: Move(); break;
            case State.Attack: Attack(); break;
            case State.Damage: Damage(); break;
            case State.Jump: Jump(); break;
            case State.Die: Die(); break;
        }
    }

    State TestChangeState(State s)
    {
        State inState = s;

        inState = JumpCheck(inState);
        inState = DamageCheck(inState);
        inState = DieCheck(inState);

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            inState = State.Idle;
            animator.SetBool(moveStateValue, false); //Move
            animator.SetBool(attackStateValue, false); //Attack
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) inState = State.Move;
        else if (Input.GetKeyDown(KeyCode.Alpha3)) inState = State.Attack;
        else if (Input.GetKeyDown(KeyCode.Alpha4)) inState = State.Damage;
        else if (Input.GetKeyDown(KeyCode.Alpha5)) inState = State.Jump;
        else if (Input.GetKeyDown(KeyCode.Alpha6)) inState = State.Die;

        return inState;
    }
    public void Idle()
    {
        Debug.Log("Idle");
        if(distance < searchDistance)
        {
            state = State.Move;
        }
    }

    public void Move()
    {
        TargetDistance();
    }

    void TargetDistance()
    {
        if (!moveStateCheck) moveStateNums = Random.Range(0, moveStateMaxNums);
        if (distance > AttackDistance)
        {
            moveStateCheck = true;
            animator.SetBool(moveStateValue, true); //Move
            animator.SetBool(attackStateValue, false); //Attack
            animator.SetInteger(moveRandomNums, moveStateNums);
        }
        else
        {
            moveStateCheck = false;
            animator.SetBool(moveStateValue, false); //Move
            animator.SetBool(attackStateValue, true); //Attack
        }
        //Debug.Log("Distace : " + distance);
    }

    public void Attack()
    {
        //공격관련 동작
        animator.SetBool(attackStateValue, false); //Attack
        animator.SetBool(moveStateValue, true); //Move
    }

    State DamageCheck(State s)
    {
        State inState = s;
        if (inState == State.Damage)
        {
            if (animator.GetBool(damageStateValue))
            {
                inState = State.Idle;
                animator.SetBool(damageStateValue, false); //Damage
            }
            else
            {
                animator.SetBool(damageStateValue, true);
                animator.SetBool(attackStateValue, false); //Attack
                animator.SetBool(jumpStateValue, false); //Jump
                animator.SetBool(moveStateValue, false); //Move
            }
        }
        return inState;
    }
    public void Damage()
    {
        //HP가 줄어드는 동작
        damageStateNums = Random.Range(0, damageStateMaxNums);
        animator.SetInteger(damageRandomNums, damageStateNums);
        Debug.Log("Hp Down!!!");
    }

    State JumpCheck(State s)
    {
        State inState = s;
        if (inState == State.Jump)
        {
            if (animator.GetBool(jumpStateValue))
            {
                inState = State.Idle;
                animator.SetBool(jumpStateValue, false);
            }
            else
            {
                animator.SetBool(jumpStateValue, true);
                animator.SetBool(attackStateValue, false); //Attack
                animator.SetBool(moveStateValue, false); //Move
            }
            //inState = State.Idle;
        }

        return inState;
    }

    public void Jump()
    {
        jumpStateNums = Random.Range(0, jumpStateMaxNums);
        animator.SetInteger(jumpRandomNums, jumpStateNums);
    }

    State DieCheck(State s)
    {
        State inState = s;
        if (inState == State.Die)
        {
            if (animator.GetBool(dieStateValue))
            {
                inState = State.Exit;
                animator.SetBool(dieStateValue, false);
                Destroy(gameObject,2);
            }
            else
            {
                animator.SetBool(dieStateValue, true);
                animator.SetBool(attackStateValue, false); //Attack
                animator.SetBool(moveStateValue, false); //Move
                animator.SetBool(jumpStateValue, false); //Jump
            }
        }
        return inState;
    }

    public void Die()
    {
        dieStateNums = Random.Range(0, dieStateMaxNums);
        animator.SetInteger(dieRandomNums, dieStateNums);
    }
}
