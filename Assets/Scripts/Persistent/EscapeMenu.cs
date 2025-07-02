using UnityEngine;

public class EscapeMenu : MonoBehaviour
{
    private bool InMenu;
    private MovementDisable MovementDisable;
    private UIManager UIManager;
    public GameObject MenuOverlay;

    private void Start()
    {
        MovementDisable = FindFirstObjectByType<MovementDisable>();
        UIManager = FindFirstObjectByType<UIManager>();
    }


    private void Update()
    {
        if (Input.GetButtonDown("Menu") && InMenu)
        {
            CloseMenu();
            //MovementDisable.EnableMovement();
            //MenuOverlay.SetActive(false);
            //InMenu = false;
            //UIManager.RemoveActiveOverlay("Menu");

        }
        else
        if (Input.GetButtonDown("Menu") && !UIManager.IsOverlayActive())
        {
            OpenMenu();
            //MenuOverlay.SetActive(true);
            //InMenu = true;
            //UIManager.AddActiveOverlay("Menu");
            //MovementDisable.DisableMovement();

        }
    }

    public void OpenMenu()
    {
        MenuOverlay.SetActive(true);
        InMenu = true;
        UIManager.AddActiveOverlay("Menu");
        MovementDisable.DisableMovement();
    }
    public void CloseMenu() 
    {
        MovementDisable.EnableMovement();
        MenuOverlay.SetActive(false);
        InMenu = false;
        UIManager.RemoveActiveOverlay("Menu");
    }
}
