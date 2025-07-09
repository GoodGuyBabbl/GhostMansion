using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ExitButtonRooms : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    private Image Renderer;
    private MovementDisable MovementDisable;
    private UIManager UIManager;

    public AK.Wwise.Event PlayClick;
    public AK.Wwise.Event PlayButton;

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
        PlayButton.Post(gameObject);
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
            PlayClick.Post(gameObject);
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
