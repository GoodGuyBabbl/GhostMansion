using UnityEngine;

public class DialogueBox : MonoBehaviour
{
    private Animator Animator;
    private RoomNPC RoomNPC;

    private void Awake()
    {
        Animator = GetComponent<Animator>();  
        RoomNPC = FindFirstObjectByType<RoomNPC>();
    }
    private void OnEnable()
    {
        if(RoomNPC.GetComponent<Animator>().GetBool("IsColored") || RoomNPC.GetComponent<Animator>().GetBool("InstantColor"))
        {
            Animator.SetBool("IsColored", true);
        }
    }
}
