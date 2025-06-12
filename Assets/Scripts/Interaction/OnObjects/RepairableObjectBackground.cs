using UnityEngine;

public class RepairableObjectBackground : MonoBehaviour
{
    public Sprite Sprite;

    private SpriteRenderer SpriteRenderer;

    private void Awake()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {

    }
    public void IsRepaired()
    {
        SpriteRenderer.sprite = Sprite;
    }
}
