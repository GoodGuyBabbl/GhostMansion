using UnityEngine;

public class ComingSoonIcon : TriggerInteraction
{
    public GameObject InteractionIcon;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        InteractionIcon.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        base.OnTriggerExit2D(collision);
        InteractionIcon.SetActive(false);
    }
}
