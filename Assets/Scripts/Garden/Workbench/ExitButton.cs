using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    private WorkbenchInteraction Workbench;
    private Image Renderer;
    private MovementDisable MovementDisable;
    private UIManager UIManager;

    public AK.Wwise.Event PlayButton;
    public AK.Wwise.Event PlayClick;
    private void Awake()
    {
        Workbench = FindFirstObjectByType<WorkbenchInteraction>();
        MovementDisable = FindFirstObjectByType<MovementDisable>();
        UIManager = FindFirstObjectByType<UIManager>();
        Renderer = GetComponent<Image>();
    }
    private void OnEnable()
    {
        Renderer.enabled = false;
    }
    public void OnSelect(BaseEventData eventData)
    {
        PlayButton.Post(gameObject);
        Renderer.enabled = true;
    }

    public void OnDeselect(BaseEventData eventData)
    {
        Renderer.enabled = false;
    }

    public void OnClick()
    {
        PlayClick.Post(gameObject);
        if (Renderer.enabled)
        {
            Debug.Log("ShouldWork");
            UIManager.EnableToolbar();  
            Workbench.InOverlay = false;
            MovementDisable.EnableMovement();
            transform.parent.gameObject.SetActive(false);
        }
    }
}
