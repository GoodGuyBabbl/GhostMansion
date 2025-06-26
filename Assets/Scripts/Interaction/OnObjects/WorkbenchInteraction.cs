using UnityEngine;
using UnityEngine.UI;

public class WorkbenchInteraction : TriggerInteraction
{
    public GameObject WorkbenchOverlay;

    private UIManager UIManager;
    private MovementDisable MovementDisable;
    public CraftButton FirstActiveButton;
    

    public bool InOverlay;

    public AK.Wwise.Event PlayConstructionPlanOpen;

    public void Start()
    {
        base.Start();
        MovementDisable = FindFirstObjectByType<MovementDisable>();
        UIManager = FindFirstObjectByType<UIManager>(); 
    }

    public override void Interact()
    {
        PlayConstructionPlanOpen.Post(gameObject);
        //open interactable Workbench UI
        if(WorkbenchOverlay.activeSelf == false && !InOverlay) 
        {
            InOverlay = true;
            WorkbenchOverlay.SetActive(true);
            FirstActiveButton.SelectButton();
            MovementDisable.DisableMovement();
            UIManager.DisableToolbar();
        }
        else if(Input.GetKeyDown(KeyCode.Escape)) 
        {
            WorkbenchOverlay.SetActive(false);
            MovementDisable.EnableMovement();
        }
        
        
    }

}
