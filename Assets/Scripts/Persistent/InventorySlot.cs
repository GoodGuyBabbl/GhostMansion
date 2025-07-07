using TMPro;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    public DroppedResource Prefab;
    private TextMeshProUGUI TextField;
    private MaterialHandler MaterialHandler;



    private void OnEnable()
    {
        MaterialHandler = FindFirstObjectByType<MaterialHandler>();
        TextField = GetComponent<TextMeshProUGUI>();
        TextField.text = MaterialHandler.GetResourceCount(Prefab.ResourceName).ToString();
    }
}
