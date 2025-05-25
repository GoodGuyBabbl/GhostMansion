using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Security.Cryptography;
using UnityEngine.EventSystems;

public class DialogueChoiceButton : MonoBehaviour, ISelectHandler
{
    [Header("Components")]
    [SerializeField] private Button Button;
    [SerializeField] private TextMeshProUGUI choiceText;

    private int ChoiceIndex = -1;

    private RoomNPC RoomNpc;

    private void Start()
    {
        RoomNpc = FindFirstObjectByType<RoomNPC>();
    }
    public void SetChoiceText(string choiceTextString)
    {
        choiceText.text = choiceTextString;
    }

    public void SetChoiceIndex(int choiceIndex)
    {
        ChoiceIndex = choiceIndex;
    }

    public void SelectButton()
    {
        Button.Select();
    }

    public void OnSelect(BaseEventData eventData)
    {
        RoomNpc.UpdateChoiceIndex(ChoiceIndex);
    }
}
