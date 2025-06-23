using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameExitButton : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    private Image Renderer;
    [SerializeField] private Button Button;

    public AK.Wwise.Event PlayClick;
    public AK.Wwise.Event PlayButton;

    private void Awake()
    {
        Renderer = GetComponent<Image>();
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
            Application.Quit();
        }
    }
}

