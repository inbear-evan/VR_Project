using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCharatorState : MonoBehaviour
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
    public float attackDistance = 3;
    public float searchDistance = 6;
    CharacterController controller;

    float distance;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        state = State.Idle;
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, target.transform.position);

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            state = State.Idle;
            animator.SetTrigger("Idle");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            state = State.Move;
            animator.SetTrigger("Move");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            state = State.Attack;
            animator.SetTrigger("Attack");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            state = State.Damage;
            animator.SetTrigger("Damage");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            state = State.Jump;
            animator.SetTrigger("Jump");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            state = State.Die;
            animator.SetTrigger("Die");
        }

        StateChange(state);
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
    public void Idle()
    {
        Debug.Log("Idle");
        if (distance < searchDistance)
        {
            animator.SetTrigger("Move");
        }
    }

    public void Move()
    {
        Debug.Log("Move");
        if (distance < attackDistance)
        {
            animator.SetTrigger("Attack");
        }
        else
        {
            animator.SetTrigger("Move");
        }
    }

    public void Attack()
    {
        //공격관련 동작
        Debug.Log("Attack");
        animator.SetTrigger("Move");
    }

    public void Damage()
    {
        //HP가 줄어드는 동작
        Debug.Log("Damage");
        animator.SetTrigger("Idle");
    }

    public void Jump()
    {
        Debug.Log("Jump");
        animator.SetTrigger("Idle");
    }

    public void Die()
    {
        Debug.Log("Die");
        Destroy(gameObject, 2);
    }
}
