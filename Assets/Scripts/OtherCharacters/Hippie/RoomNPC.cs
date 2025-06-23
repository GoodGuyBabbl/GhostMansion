using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using Ink;
using TMPro;

public class RoomNPC : TriggerInteraction
{
    [Header("Dialogue")]
    [SerializeField] public string DialogueKnotName;

    public bool IsRepairEnabled;
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
    private Stories StoryManager;
    public UniqueID UniqueID;
    private SaveStateManager SaveStateManager;

    public string StoryName;
    public int CurrentChoiceIndex = -1;

    public AK.Wwise.Event PlayGhost;

    public void Awake()
    {
        StoryManager = FindFirstObjectByType<Stories>();
        MovementDisable = FindFirstObjectByType<MovementDisable>();
        UIManager = FindFirstObjectByType<UIManager>();
        UniqueID = GetComponent<UniqueID>();
        SaveStateManager = FindFirstObjectByType<SaveStateManager>();
    }
    private void Start()
    {
        base.Start();
        Story = StoryManager.GetStory(StoryName);
        ResetPanelText();
        DialogueKnotName = SaveStateManager.GetCurrentStory(StoryName);
        IsRepairEnabled = SaveStateManager.GetIsRepairEnabled(UniqueID.ID);
        

    }


    //RoomNPC
    public void Update()
    {
        base.Update();

    }

    //RoomNPC
    public bool GetIsRepairEnabled()
    {
        return IsRepairEnabled;
    }


    //RoomNPC
    public void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        Debug.Log(Story.variablesState["NextDialogueKnot"]);
        //if (!HasBeenTalkedTo)
        // {
        NPCTalkIcon.SetActive(true);
        //}
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

        Debug.Log(Story.variablesState["NextDialogueKnot"]);
        ContinueOrExitStory();

    }


    //DialogueManager
    private void ContinueOrExitStory()
    {

        if (Story.currentChoices.Count > 0 && CurrentChoiceIndex != -1)
        {
            Story.ChooseChoiceIndex(CurrentChoiceIndex);
            CurrentChoiceIndex = -1;
        }
        if (Story.canContinue)
        {
            string DialogueLine = Story.Continue();

            while (BlankLineSkip(DialogueLine) && Story.canContinue)
            {
                DialogueLine = Story.Continue();
            }

            if(BlankLineSkip(DialogueLine) && !Story.canContinue)
            {
                ExitDialogue();
            }
            else
            {
                DisplayDialogue(DialogueLine, Story.currentChoices);
            }
            
            //Debug.Log(DialogueLine);
        }
        else if(Story.currentChoices.Count == 0) 
        {
            ExitDialogue();
        }
    }

    //DialogueManager
    private void ExitDialogue()
    {
        CheckRepairUnlock();
        ResetPanelText();
        NPCDialogueCanvas.SetActive(false);
        UIManager.EnableToolbar();
        MovementDisable.EnableMovement();
        IsDialoguePlaying = false;
        //HasBeenTalkedTo = true;
        SetKnotNameFromInk();
        SaveStateManager.SetCurrentStory(StoryName, DialogueKnotName);
        Debug.Log(Story.variablesState["NextDialogueKnot"]);
        Story.ResetState();
        Debug.Log(Story.variablesState["NextDialogueKnot"]);

        Debug.Log("ExitDialogue");
        
    }


    //DialogueManager
    public void DisplayDialogue(string DialogueLine, List<Choice> DialogueChoices)
    {
        DialogueText.text = DialogueLine;

        

        //DialogueText.text = DialogueLine;

        if (DialogueChoices.Count > ChoiceButtons.Length)
        {
            Debug.LogError("Not enough dialogue buttons");
        }

        foreach (DialogueChoiceButton choiceButton in ChoiceButtons)
        {
            choiceButton.gameObject.SetActive(false);
        }

        int choiceButtonIndex = DialogueChoices.Count-1;
        for (int InkChoiceIndex = 0; InkChoiceIndex < DialogueChoices.Count; InkChoiceIndex++)
        {
            Choice DialogueChoice = DialogueChoices[InkChoiceIndex];
            DialogueChoiceButton choiceButton = ChoiceButtons[choiceButtonIndex];

            choiceButton.gameObject.SetActive(true);
            choiceButton.SetChoiceText(DialogueChoice.text);
            choiceButton.SetChoiceIndex(InkChoiceIndex);

            //Debug.Log(choiceButtonIndex);

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
        CurrentChoiceIndex = choiceIndex;//this.CurrentChoiceIndex
    }

    //DialogueManager
    private bool BlankLineSkip(string DialogueLineToCheck)
    {
        return DialogueLineToCheck.Trim().Equals("") || DialogueLineToCheck.Trim().Equals("\n");
    }

    //RoomNPC
    public override void Interact()
    {
        if (!DialogueKnotName.Equals(""))
        {
            PlayGhost.Post(gameObject);
            EnterDialogue();          
        }
        
        
    }

    //FromInk
    public void SetKnotNameFromInk()
    {
        if ((string)Story.variablesState["NextDialogueKnot"] != "")
        {
            DialogueKnotName = (string)Story.variablesState["NextDialogueKnot"];
        }
    }
    //FromInk
    public void CheckRepairUnlock() //Checks, whether the variable "CanRepairFurniture" of The NPCs InkFile has been set to true; If so, the Player can start repairing Objects.
    {
        if((bool)Story.variablesState["CanRepairFurniture"])
        {
            IsRepairEnabled = true;
            SaveStateManager.MarkRepairAsEnabled(UniqueID.ID);
            Debug.Log((bool)Story.variablesState["CanRepairFurniture"]);
        }

    }
}
