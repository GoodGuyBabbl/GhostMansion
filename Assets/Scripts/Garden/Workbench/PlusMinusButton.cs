using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlusMinusButton : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public int PosOrNeg;
    private Image Renderer;
    public CraftButton CraftButton;
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
        Renderer.enabled = true;
    }
    public void OnDeselect(BaseEventData eventData)
    {
        Renderer.enabled = false;
    }

    public void OnClick()
    {
        CraftButton.DisplayedAmountResult += 1 * PosOrNeg;
        CraftButton.DisplayedAmountResult = Mathf.Clamp(CraftButton.DisplayedAmountResult, 1, 100);
        CraftButton.UpdateNumbers();
        CraftButton.NoHoverButtonCheck();
    }
}
