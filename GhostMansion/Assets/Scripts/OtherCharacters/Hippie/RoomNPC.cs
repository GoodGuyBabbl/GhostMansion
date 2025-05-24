using UnityEngine;
using Ink.Runtime;
using Ink;

public class RoomNPC : TriggerInteraction
{
    [Header("Dialogue")]
    [SerializeField] private string DialogueKnotName;

    public bool HasBeenTalkedTo;
    public bool IsDialoguePlaying;

    public GameObject NPCTalkIcon;

    [Header("InkStory")]
    [SerializeField] private TextAsset InkFile;
    private Story Story;


    public void Awake()
    {
        Story = new Story(InkFile.text);
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
        Debug.Log(Story.canContinue);
        if (Story.canContinue)
        {
            string DialogueLine = Story.Continue();
            Debug.Log(DialogueLine);
        }
        else
        {
            ExitDialogue();
        }
    }

    //DialogueManager
    private void ExitDialogue()
    {
        IsDialoguePlaying = false;
        HasBeenTalkedTo = true;
        Story.ResetState();
        //Textbox Inactive setzen
        Debug.Log("ExitDialogue");
    }

    //RoomNPC
    public override void Interact()
    {
        if (!DialogueKnotName.Equals(""))
        {
            EnterDialogue();
            
            
        }
        
        
    }
}
