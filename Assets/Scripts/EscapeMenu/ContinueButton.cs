using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ContinueButton : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    private Image Renderer;
    [SerializeField] private Button Button;
    private EscapeMenu EscapeMenu;

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
        Renderer.enabled = true;
    }

    public void OnDeselect(BaseEventData eventData)
    {
        Renderer.enabled = false;
    }

    public void OnClick()
    {
        EscapeMenu.CloseMenu();
    }
}
