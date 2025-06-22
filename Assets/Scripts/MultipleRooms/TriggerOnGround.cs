using UnityEngine;

public class TriggerOnGround : TriggerInteraction
{
    public RoomNPC RoomNPC;

    private SaveStateManager SaveStateManager;
    private Stories StoryManager;
    bool testbool = false;

    private void Update()
    {
        
        base.Update(); 

    }
    private void Start()
    {
        base.Start();
        SaveStateManager = FindFirstObjectByType<SaveStateManager>();
        StoryManager = FindFirstObjectByType<Stories>();
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
