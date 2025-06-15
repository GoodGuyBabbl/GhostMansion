using UnityEngine;

public class ColorRoomNPC : MonoBehaviour
{
    private Animator Animator;

    void Start()
    {
        Animator = GetComponent<Animator>();
    }

    public void ColorNPC()
    {
        Animator.SetBool("IsColored", true);
    }
}
