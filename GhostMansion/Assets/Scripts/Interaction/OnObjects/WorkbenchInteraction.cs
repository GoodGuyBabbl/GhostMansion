using UnityEngine;
using UnityEngine.UI;

public class WorkbenchInteraction : TriggerInteraction
{
    public GameObject WorkbenchOverlay;

    private MovementDisable MovementDisable;

    public void Start()
    {
        base.Start();
        MovementDisable = FindFirstObjectByType<MovementDisable>();
    }

    public override void Interact()
    {
        //open Workbench UI
        if(WorkbenchOverlay.activeSelf == false) 
        {
            WorkbenchOverlay.SetActive(true);
            MovementDisable.DisableMovement();
        }
        else
        {
            WorkbenchOverlay.SetActive(false);
            MovementDisable.EnableMovement();
        }
        
        //stop movement
    }

}
