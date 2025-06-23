using UnityEngine;

public class ColorChangeController : MonoBehaviour
{

    public int RepairableObjectsAmount;
    public GameObject BackgroundToChangeColor;

    private Animator Animator;
    private int RepairedObjects;

    void Start()
    {
        Animator = BackgroundToChangeColor.GetComponent<Animator>();
    }

    public void IncrementRepairedObjects()
    {
        RepairedObjects++;
    }

    public void CheckColorChange()
    {
        if (RepairedObjects == RepairableObjectsAmount)
        {
            Animator.SetBool("RoomIsRepaired", true);
        }
    }
}
