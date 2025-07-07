using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ContinueButton : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    private Image Renderer;
    [SerializeField] private Button Button;
    private EscapeMenu EscapeMenu;

    public AK.Wwise.Event PlayClick;
    public AK.Wwise.Event PlayButton;

    private void Awake()
    {
        Renderer = GetComponent<Image>();
        Button.Select();
    }
    void Start()
    {
        EscapeMenu = FindFirstObjectByType<EscapeMenu>();
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
        EscapeMenu.CloseMenu();
    }
}
