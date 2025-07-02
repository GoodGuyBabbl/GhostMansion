using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ExitButtonRooms : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    private Image Renderer;
    private MovementDisable MovementDisable;
    private UIManager UIManager;
    private void Awake()
    {
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
            //Debug.Log("ShouldWork");
            StartCoroutine(ClosePage());
        }
    }
    private IEnumerator ClosePage()
    {
        yield return null;
        UIManager.EnableToolbar();
        UIManager.RemoveActiveOverlay("Buildplot");
        MovementDisable.EnableMovement();
        transform.parent.gameObject.SetActive(false);

    }
}
