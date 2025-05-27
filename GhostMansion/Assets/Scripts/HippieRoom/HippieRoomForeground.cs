using UnityEngine;

public class HippieRoomForeground : MonoBehaviour
{

    public void ActivateColorChange()
    {
        GetComponent<Animator>().SetBool("RoomIsRepaired", true);
    }
}
