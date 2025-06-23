using UnityEngine;

public interface Interactable
{
    public GameObject Player { get; set; }

    public bool CanInteract {  get; set; }

    public void Interact();

}
