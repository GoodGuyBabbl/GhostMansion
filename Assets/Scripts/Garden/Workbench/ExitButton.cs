using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    private WorkbenchInteraction Workbench;
    private Image Renderer;
    private MovementDisable MovementDisable;
    private UIManager UIManager;
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
        Renderer.enabled = true;
    }

    public void OnDeselect(BaseEventData eventData)
    {
        Renderer.enabled = false;
    }

    public void OnClick()
    {
        if (Renderer.enabled)
        {
            Debug.Log("ShouldWork");
            UIManager.EnableToolbar();
            UIManager.RemoveActiveOverlay("Workbench");
            MovementDisable.EnableMovement();
            transform.parent.gameObject.SetActive(false);
        }
    }
}
