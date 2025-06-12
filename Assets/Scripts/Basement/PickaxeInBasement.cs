using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using Ink;
using System.Security.Cryptography.X509Certificates;

public class PickaxeInBasement : TriggerInteraction
{
    public GameObject InteractionIcon;
    private Story Story;
    
    private UIManager UIManager;
    private Stories StoryManager;

    private SaveStateManager SaveStateManager;

    private void Awake()
    {
        StoryManager = FindFirstObjectByType<Stories>();
        SaveStateManager = FindFirstObjectByType<SaveStateManager>();
    }
    public void Start()
    {
        Story = StoryManager.GetStory("TutorialGhostStory");
        base.Start();
        UIManager = FindFirstObjectByType<UIManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        InteractionIcon.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        base.OnTriggerExit2D (collision);
        InteractionIcon.SetActive(false);
    }

    public override void Interact()
    {
        Story.variablesState["NextDialogueKnot"] = "PickaxePickedUp";
        SaveStateManager.SetCurrentStory("TutorialGhostStory", "PickaxePickedUp");
        // geht nur, wenn Story Szenenübergreifend gespeichert wird. Story.variablesState["NextDialogueKnot"] = "PickaxePickedUp";
        Debug.Log(Story.variablesState["NextDialogueKnot"]);
        UIManager.CollectPickaxe();
        UIManager.EnablePickaxe();
        InteractionIcon.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
