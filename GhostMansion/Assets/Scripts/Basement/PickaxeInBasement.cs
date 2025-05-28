using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using Ink;

public class PickaxeInBasement : TriggerInteraction
{
    public GameObject InteractionIcon;
    [SerializeField] private TextAsset InkFile;
    public Story Story;
    
    private UIManager UIManager;

    public void Start()
    {
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
        UIManager.CollectPickaxe();
        UIManager.EnablePickaxe();
        InteractionIcon.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
