using UnityEngine;

public class ActivateBasementDoor : StateMachineBehaviour
{
    
    

    // Wird aufgerufen, wenn der State verlassen wird
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Carpet Carpet = FindFirstObjectByType<Carpet>();
        Carpet.ActivateBasementDoor();
    }
}

