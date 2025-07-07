using System.Drawing;
using UnityEngine;

public class ColorChangeController : MonoBehaviour
{

    public int RepairableObjectsAmount;
    public GameObject BackgroundToChangeColor;


    public Animator Animator;
    public int RepairedObjects;
    private RoomNPC RoomNPC;
    private SaveStateManager SaveStateManager;


    void Start()
    {
        SaveStateManager = FindFirstObjectByType<SaveStateManager>();
        RoomNPC = FindFirstObjectByType<RoomNPC>();
        Animator = BackgroundToChangeColor.GetComponent<Animator>();
        if(SaveStateManager.HasDoneRepairCount(RoomNPC.GetComponent<UniqueID>().ID))
        {
            RepairedObjects = SaveStateManager.GetDoneRepairCount(RoomNPC.GetComponent<UniqueID>().ID);
        }
        if(RepairedObjects == RepairableObjectsAmount)
        {
            Animator.SetBool("InstantRepair", true);
        }
    }

    public void IncrementRepairedObjects()
    {
        RepairedObjects++;
        SaveStateManager.SaveDoneRepairCount(RoomNPC.GetComponent<UniqueID>().ID, RepairedObjects);
    }

    public void CheckColorChange()
    {
        if (RepairedObjects == RepairableObjectsAmount)
        {
            Animator.SetBool("RoomIsRepaired", true);
            SaveStateManager.SetCurrentStory(RoomNPC.StoryName, "RoomRepaired");
            RoomNPC.DialogueKnotName = "RoomRepaired";
        }
    }
}
