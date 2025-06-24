using UnityEngine;

public class Inventory : MonoBehaviour
{

    private bool InInventory;
    private MovementDisable MovementDisable;
    private UIManager UIManager;
    public GameObject InventoryOverlay;


    private void Start()
    {
        MovementDisable = FindFirstObjectByType<MovementDisable>();
        UIManager = FindFirstObjectByType<UIManager>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Inventory") && InInventory)
        {
            
            MovementDisable.EnableMovement();
            InventoryOverlay.SetActive(false);
            InInventory = false;
            UIManager.RemoveActiveOverlay("Inventory");

        } else
        if (Input.GetButtonDown("Inventory") && !UIManager.IsOverlayActive())
        {
            Debug.Log(InventoryOverlay);
            InventoryOverlay.SetActive(true);
            InInventory = true;
            UIManager.AddActiveOverlay("Inventory");
            MovementDisable.DisableMovement();

        }
        
    }
}
