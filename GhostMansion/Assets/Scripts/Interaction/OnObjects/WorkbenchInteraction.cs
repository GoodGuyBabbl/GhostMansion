using UnityEngine;
using UnityEngine.UI;

public class WorkbenchInteraction : TriggerInteraction
{
    public GameObject WorkbenchOverlay;

    
    public override void Interact()
    {
        //open Workbench UI
        WorkbenchOverlay.SetActive(true);
        //stop movement
    }

}
