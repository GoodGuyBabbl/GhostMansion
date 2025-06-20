using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using Ink;

public class CollectableTool : TriggerInteraction
{
    public GameObject InteractionIcon;

    private UIManager UIManager;

    private SaveStateManager SaveStateManager;
    private UniqueID UniqueID;

    private void Awake()
    {
        SaveStateManager = FindFirstObjectByType<SaveStateManager>();
    }
    public void Start()
    {
        UniqueID = GetComponent<UniqueID>();
        base.Start();
        UIManager = FindFirstObjectByType<UIManager>();
        if (SaveStateManager.IsObjectChanged(UniqueID.ID))
        {
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        InteractionIcon.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        base.OnTriggerExit2D(collision);
        InteractionIcon.SetActive(false);
    }

    public override void Interact()
    {
        // geht nur, wenn Story Szenenübergreifend gespeichert wird. Story.variablesState["NextDialogueKnot"] = "PickaxePickedUp";
        UIManager.CollectInsectNet();
        UIManager.EnableInsectNet();
        InteractionIcon.SetActive(false);
        SaveStateManager.MarkObjectAsChanged(UniqueID.ID);
        this.gameObject.SetActive(false);
    }
}
