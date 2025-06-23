using UnityEngine;
using Ink.Runtime;
using Ink;

public class Carpet : TriggerInteraction
{
    public GameObject InteractionIcon;
    public GameObject BasementDoor;
    public GameObject DoorIconToBasement;

    private Animator Animator;
    private SaveStateManager SaveStateManager;
    private UniqueID UniqueID;

    public bool IsCarpetEnabled;

    //Wwise
    public AK.Wwise.Event PlayRollUpCarpet;

    private void Awake()
    {
        UniqueID = GetComponent<UniqueID>();
        SaveStateManager = FindFirstObjectByType<SaveStateManager>();
        Animator = GetComponent<Animator>();
        if (SaveStateManager.IsObjectChanged(UniqueID.ID))
        {
            Animator.SetBool("InstantRoll", true);
            ActivateBasementDoor();
            ActivateBasementDoor();
        }
    }
    public void Start()
    {
        base.Start();
        
    }
    public void Update()
    {
        base.Update();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(IsCarpetEnabled)
        {
            if (Animator.GetBool("InstantRoll"))
            {
                Animator.SetBool("WasClicked", true);
            }
            base.OnTriggerEnter2D(collision);
            if (!Animator.GetBool("WasClicked"))
            {
                InteractionIcon.SetActive(true);
            }
        }
               
         
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        base.OnTriggerExit2D(collision);
        if(InteractionIcon)
        {
            InteractionIcon.SetActive(false);
        }
    }

    public override void Interact()
    {
        PlayRollUpCarpet.Post(gameObject);
        InteractionIcon.SetActive(false);
        Animator.SetBool("WasClicked",true);
        SaveStateManager.MarkObjectAsChanged(UniqueID.ID);
    }
  
    public void ActivateBasementDoor()
    {
        BasementDoor.SetActive(true);
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
