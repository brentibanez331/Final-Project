using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooldown : StateMachineBehaviour
{
    [SerializeField] private float duration = 5f;
    private float timer;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = duration;
    }
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {    
        timer -= Time.deltaTime;
        //Debug.Log(timer);
        if (timer <= 0)
        {
            animator.SetBool("isAttackDone", true);
            //Debug.Log("attack is done");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isAttackDone", false);
    }
}
