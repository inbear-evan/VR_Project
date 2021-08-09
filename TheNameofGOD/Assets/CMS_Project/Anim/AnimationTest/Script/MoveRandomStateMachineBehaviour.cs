using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRandomStateMachineBehaviour : StateMachineBehaviour
{

    public int numberOfStates = 2;
    readonly int hashRandomIdel = Animator.StringToHash("RandomMove");
    bool stateCheck = false;
    int stateNum;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    if (!stateCheck)
    //    {
    //        stateNum = Random.Range(0, numberOfStates);
    //        stateCheck = true;
    //    }
    //    //animator.SetInteger(hashRandomIdel, stateNum);

    //}

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    if (animator.IsInTransition(0) && animator.GetCurrentAnimatorStateInfo(0).fullPathHash == stateInfo.fullPathHash)
    //    {
    //        animator.SetInteger(hashRandomIdel, stateNum);
    //    }
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    stateCheck = false;
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
