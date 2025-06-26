using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlusMinusButton : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public int PosOrNeg;
    private Image Renderer;
    public CraftButton CraftButton;

    public AK.Wwise.Event PlayButton;
    public AK.Wwise.Event PlayClick;

    private void Awake()
    {
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
        CraftButton.DisplayedAmountResult += 1 * PosOrNeg;
        CraftButton.DisplayedAmountResult = Mathf.Clamp(CraftButton.DisplayedAmountResult, 1, 100);
        CraftButton.UpdateNumbers();
        CraftButton.NoHoverButtonCheck();
    }
}
