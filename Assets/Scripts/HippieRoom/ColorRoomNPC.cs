using UnityEngine;

public class ColorRoomNPC : MonoBehaviour
{
    private Animator Animator;
    private ColorChangeController ColorChangeController;
    public GameObject Dialoguebox;

    public GameObject NPCTransition;

    void Start()
    {
        Animator = GetComponent<Animator>();
        ColorChangeController = FindFirstObjectByType<ColorChangeController>();
    }



    public void ColorNPC()
    {
        if (ColorChangeController.Animator.GetBool("InstantRepair"))
        {
            Animator.SetBool("InstantColor", true);
            Debug.Log("Colored");
        }
        else
        {
            Animator.SetBool("IsColored", true);
            NPCTransition.GetComponent<Animator>().SetTrigger("Transition");
        }
    }
}
