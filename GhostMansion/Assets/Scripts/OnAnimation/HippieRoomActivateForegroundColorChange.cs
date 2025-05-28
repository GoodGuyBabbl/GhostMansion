using UnityEngine;

public class HippieRoomActivateForegroundColorChange : StateMachineBehaviour
{
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        HippieRoomForeground Foreground = FindFirstObjectByType<HippieRoomForeground>();
        Foreground.ActivateColorChange();
        HippieCharacterColored Character = FindFirstObjectByType<HippieCharacterColored>();
        Character.ColorHippie();
    }
}
