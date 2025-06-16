using UnityEngine;
using UnityEngine.InputSystem;

public class Carpet : TriggerInteraction
{
    public GameObject InteractionIcon;
    public GameObject BasementDoor;
    public GameObject DoorIconToBasement;

    private Animator Animator;

    public AK.Wwise.Event PlayRollUpCarpet;

    public void Start()
    {
        base.Start();
        Animator = GetComponent<Animator>(); 
    }
    public void Update()
    {
        base.Update();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if(!Animator.GetBool("WasClicked"))
        {
            InteractionIcon.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        base.OnTriggerExit2D(collision);
        if(InteractionIcon.activeSelf)
        {
            InteractionIcon.SetActive(false);
        }
    }

    public override void Interact()
    {
        PlayRollUpCarpet.Post(gameObject);
        InteractionIcon.SetActive(false);
        Animator.SetBool("WasClicked",true);
    }
  
    public void ActivateBasementDoor()
    {
        BasementDoor.SetActive(true);
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
