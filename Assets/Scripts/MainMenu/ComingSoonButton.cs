using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ComingSoonButton : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    private Image Renderer;
    [SerializeField] private Button Button;

    private void Awake()
    {
        Renderer = GetComponent<Image>();
    }
    public void OnSelect(BaseEventData eventData)
    {
        Renderer.enabled = true;
    }

    public void OnDeselect(BaseEventData eventData)
    {
        Renderer.enabled = false;
    }
}
