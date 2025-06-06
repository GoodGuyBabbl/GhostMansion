using UnityEngine;

public class HippieCharacterColored : MonoBehaviour
{
    private SpriteRenderer SpriteRenderer;
    public Sprite ColoredSprite;
    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ColorHippie()
    {
        SpriteRenderer.sprite = ColoredSprite;
    }
}
