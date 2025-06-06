using UnityEngine;


public class TriggerInteraction : MonoBehaviour, Interactable
{
    public GameObject Player { get; set; }
    public bool CanInteract { get ; set; }


    public void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Update()
    {
        if (CanInteract)
        {
            if (Interactions.WasInteractPressed)
            {
                Interact();
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Player)
        {
            CanInteract = true;
        }
        
    }

    public void OnTriggerExit2D(Collider2D collision)
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
