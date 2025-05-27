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
        Story = new Story(InkFile.text);
        Story.variablesState["NextDialogueKnot"] = "PickaxePickedUp";
        InteractionIcon.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
