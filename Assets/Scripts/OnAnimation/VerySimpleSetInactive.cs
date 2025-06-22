using Unity.VisualScripting;
using UnityEngine;

public class VerySimpleSetInactive : StateMachineBehaviour
{
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.gameObject.SetActive(false);
    }
}
