using UnityEngine;

public class RoomNPC : TriggerInteraction
{
    public bool HasBeenTalkedTo;

    public GameObject NPCTalkIcon;





    public void Update()
    {
        base.Update();

    }


    public bool GetHasBeenTalkedTo()
    {
        return HasBeenTalkedTo;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (!HasBeenTalkedTo)
        {
            NPCTalkIcon.SetActive(true);
        }
    }



    public void OnTriggerExit2D(Collider2D collision)
    {
        base.OnTriggerExit2D(collision);
        NPCTalkIcon.SetActive(false);
    }

    public override void Interact()
    {
        HasBeenTalkedTo = true;
        NPCTalkIcon.SetActive(false);
    }
}
