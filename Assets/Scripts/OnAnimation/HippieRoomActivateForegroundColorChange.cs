using UnityEngine;

public class HippieRoomActivateForegroundColorChange : StateMachineBehaviour
{
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        HippieRoomForeground Foreground = FindFirstObjectByType<HippieRoomForeground>();
        Foreground.ActivateColorChange();
        ColorRoomNPC Character = FindFirstObjectByType<ColorRoomNPC>();
        Character.ColorNPC();
    }
}
