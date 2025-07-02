using UnityEngine;
using UnityEngine.UI;

public class WorkbenchInteraction : TriggerInteraction
{
    public GameObject WorkbenchOverlay;

    private UIManager UIManager;
    private MovementDisable MovementDisable;
    public CraftButton FirstActiveButton;
    

    public bool InOverlay;
    
    public void Start()
    {
        base.Start();
        MovementDisable = FindFirstObjectByType<MovementDisable>();
        UIManager = FindFirstObjectByType<UIManager>(); 
    }

    public override void Interact()
    {
        //open interactable Workbench UI
        if(WorkbenchOverlay.activeSelf == false && !UIManager.IsOverlayActive()) 
        {
            UIManager.AddActiveOverlay("Workbench");
            WorkbenchOverlay.SetActive(true);
            FirstActiveButton.SelectButton();
            MovementDisable.DisableMovement();
            UIManager.DisableToolbar();
        }
        else if(Input.GetKeyDown(KeyCode.Escape)) 
        {
            //WorkbenchOverlay.SetActive(false);
            //MovementDisable.EnableMovement();
        }
        
        
    }

}
