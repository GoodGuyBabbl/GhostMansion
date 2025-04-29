using UnityEngine;


public class TriggerInteraction : MonoBehaviour, Interactable
{
    public GameObject Player { get; set; }
    public bool CanInteract { get ; set; }


    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (CanInteract)
        {
            if(Interactions.WasInteractPressed)
            {
                Interact();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Player)
        {
            CanInteract = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == Player)
        {
            CanInteract = false;
        }
    }
    public virtual void Interact()
    {
        
    }
}
