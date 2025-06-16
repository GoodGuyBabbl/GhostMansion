using UnityEngine;
using UnityEngine.UI;

public class WorkbenchInteraction : TriggerInteraction
{
    public GameObject WorkbenchOverlay;

    private MovementDisable MovementDisable;

    public AK.Wwise.Event PlayConstructionPlanOpen;

    public void Start()
    {
        base.Start();
        MovementDisable = FindFirstObjectByType<MovementDisable>();
    }

    public override void Interact()
    {
        PlayConstructionPlanOpen.Post(gameObject);
        //open interactable Workbench UI
        if (WorkbenchOverlay.activeSelf == false) 
        {
            WorkbenchOverlay.SetActive(true);
            MovementDisable.DisableMovement();
        }
        else if(Input.GetKeyDown(KeyCode.Escape)) 
        {
            WorkbenchOverlay.SetActive(false);
            MovementDisable.EnableMovement();
        }
        
        
    }

}
