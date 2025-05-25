using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using Ink;
using TMPro;

public class RoomNPC : TriggerInteraction
{
    [Header("Dialogue")]
    [SerializeField] private string DialogueKnotName;

    public bool HasBeenTalkedTo;
    public bool IsDialoguePlaying;

    public GameObject NPCTalkIcon;
    public GameObject NPCDialogueCanvas;

    [Header("InkStory")]
    [SerializeField] private TextAsset InkFile;
    [SerializeField] private TextMeshProUGUI DialogueText;
    [SerializeField] private DialogueChoiceButton[] ChoiceButtons;
    private Story Story;
    private MovementDisable MovementDisable;
    private UIManager UIManager;
    private int CurrentChoiceIndex = -1;


    public void Awake()
    {
        ResetPanelText();
        Story = new Story(InkFile.text);
        MovementDisable = FindFirstObjectByType<MovementDisable>();
        UIManager = FindFirstObjectByType<UIManager>();
    }


    //RoomNPC
    public void Update()
    {
        base.Update();

    }

    //RoomNPC
    public bool GetHasBeenTalkedTo()
    {
        return HasBeenTalkedTo;
    }


    //RoomNPC
    public void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (!HasBeenTalkedTo)
        {
            NPCTalkIcon.SetActive(true);
        }
    }


    //RoomNPC
    public void OnTriggerExit2D(Collider2D collision)
    {
        base.OnTriggerExit2D(collision);

        if(NPCTalkIcon != null)
        {
            NPCTalkIcon.SetActive(false);
        }
        
    }

    //DialogueManager
    private void EnterDialogue()
    {
        
        if (IsDialoguePlaying)
        {
            ContinueOrExitStory();
            return;
        }

        IsDialoguePlaying = true;
        
        
            

        if (!DialogueKnotName.Equals(""))
        {
            UIManager.DisableToolbar();
            NPCDialogueCanvas.SetActive(true);
            MovementDisable.DisableMovement();
            Story.ChoosePathString(DialogueKnotName);
        }
        else
        {
            Debug.LogWarning("NoKnotSet");
        }


        ContinueOrExitStory();

    }


    //DialogueManager
    private void ContinueOrExitStory()
    {

        if (Story.canContinue)
        {
            string DialogueLine = Story.Continue();
            DisplayDialogue(DialogueLine, Story.currentChoices);
            //Debug.Log(DialogueLine);
        }
        else
        {
            ExitDialogue();
        }
    }

    //DialogueManager
    private void ExitDialogue()
    {
        ResetPanelText();
        NPCDialogueCanvas.SetActive(false);
        UIManager.EnableToolbar();
        MovementDisable.EnableMovement();
        IsDialoguePlaying = false;
        HasBeenTalkedTo = true;
        Story.ResetState();
        //Textbox Inactive setzen
        Debug.Log("ExitDialogue");
    }


    //DialogueManager
    public void DisplayDialogue(string DialogueLine, List<Choice> DialogueChoices)
    {
        if(Story.currentChoices.Count > 0 && CurrentChoiceIndex != -1)
        {
            Story.ChooseChoiceIndex(CurrentChoiceIndex);
            CurrentChoiceIndex = -1;
        }

        DialogueText.text = DialogueLine;

        if (DialogueChoices.Count > ChoiceButtons.Length)
        {
            Debug.LogError("Not enough dialogue buttons");
        }

        foreach (DialogueChoiceButton choiceButton in ChoiceButtons)
        {
            choiceButton.gameObject.SetActive(false);
        }

        int choiceButtonIndex = DialogueChoices.Count - 1;
        for (int InkChoiceIndex = 0; InkChoiceIndex < DialogueChoices.Count; InkChoiceIndex++)
        {
            Choice DialogueChoice = DialogueChoices[InkChoiceIndex];
            DialogueChoiceButton choiceButton = ChoiceButtons[choiceButtonIndex];

            choiceButton.gameObject.SetActive(true);
            choiceButton.SetChoiceText(DialogueChoice.text);
            choiceButton.SetChoiceIndex(InkChoiceIndex);

            if(InkChoiceIndex == 0)
            {
                choiceButton.SelectButton();
                UpdateChoiceIndex(0);
            }

            choiceButtonIndex--;


        }
    }
    private void ResetPanelText()
    {
        DialogueText.text = "";
    }


    //DialogueManager
    public void UpdateChoiceIndex(int choiceIndex)
    {
        this.CurrentChoiceIndex= choiceIndex;
    }

    //DialogueManager


    //RoomNPC
    public override void Interact()
    {
        if (!DialogueKnotName.Equals(""))
        {
            EnterDialogue();          
        }
        
        
    }
}
