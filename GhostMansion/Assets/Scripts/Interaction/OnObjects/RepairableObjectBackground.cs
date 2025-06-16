using UnityEngine;

public class RepairableObjectBackground : MonoBehaviour
{
    public Sprite Sprite;

    private SpriteRenderer SpriteRenderer;

    private void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void IsRepaired()
    {
        SpriteRenderer.sprite = Sprite;
    }
}
