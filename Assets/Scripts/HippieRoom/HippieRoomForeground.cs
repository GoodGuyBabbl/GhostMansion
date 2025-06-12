using UnityEngine;

public class HippieRoomForeground : MonoBehaviour
{
    private ColorChangeController ColorChangeController;
    private void Awake()
    {
        ColorChangeController = FindFirstObjectByType<ColorChangeController>();
    }
    private void Start()
    {
        
    }
    public void ActivateColorChange()
    {
        Debug.Log(ColorChangeController.Animator.GetBool("InstantRepair"));
        if (ColorChangeController.Animator.GetBool("InstantRepair"))
        {
            GetComponent<Animator>().SetBool("InstantRepair", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("RoomIsRepaired", true);
        }
        
    }
}
