using UnityEngine;

public class TriggerOnGround : TriggerInteraction
{
    public RoomNPC RoomNPC;

    private SaveStateManager SaveStateManager;
    public UniqueID UniqueID;
    //private Stories StoryManager;
    //public string StoryName;

    private void Update()
    {
        
        base.Update(); 

    }
    private void Start()
    {

        base.Start();
        SaveStateManager = FindFirstObjectByType<SaveStateManager>();
        UniqueID = GetComponent<UniqueID>();
        //StoryManager = FindFirstObjectByType<Stories>();
        //StoryName = RoomNPC.StoryName;
        if(SaveStateManager.GetStoryTriggerDone(UniqueID.ID))
        {
            this.gameObject.SetActive(false);
        }
        else if(!SaveStateManager.IsObjectChanged(UniqueID.ID))
        {
            this.gameObject.SetActive(false);
        }
        else if (SaveStateManager.IsObjectChanged(UniqueID.ID))
        {
            this.gameObject.SetActive(true); //obsolete, aber für clarity
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D (collision);
        RoomNPC.GetComponent<CircleCollider2D>().enabled = false;
        RoomNPC.Interact();

    }

    public override void Interact()
    {
        RoomNPC.Interact();
    }


}
