using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RoomPageButton : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public TextMeshProUGUI Text;

    private Image Renderer;

    public Sprite Sprite;

    private void Awake()
    {
        Renderer = GetComponent<Image>();
    }
    private void OnEnable()
    {
        GetComponent<CraftButton>().enabled = false;

        Renderer.sprite = Sprite;

        Text.enabled = false;
        Renderer.enabled = false;
    }
    
    public void OnSelect(BaseEventData eventData)
    {
        Text.enabled = true;
        Renderer.enabled = true;
        Renderer.sprite = Sprite;
    }

    public void OnDeselect(BaseEventData eventData)
    {
        Text.enabled = false;
        Renderer.enabled = false;
    }
    
}
