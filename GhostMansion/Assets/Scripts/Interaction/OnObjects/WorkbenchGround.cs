using UnityEngine;

public class WorkbenchGround : TriggerInteraction
{
    public Sprite WorkbenchGrey;
    public Sprite WorkbenchColored;
    public Sprite GroundGrey;
    public Sprite GroundColored;

    private SpriteRenderer WorkbenchRenderer;
    private SpriteRenderer SpriteRenderer;

    private WorkbenchInteraction Workbench;

    private void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        Workbench = FindFirstObjectByType<WorkbenchInteraction>();
        WorkbenchRenderer = Workbench.gameObject.GetComponent<SpriteRenderer>();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        SpriteRenderer.sprite = GroundColored;
        WorkbenchRenderer.sprite = WorkbenchColored;

    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        base.OnTriggerExit2D(collision);
        SpriteRenderer.sprite = GroundGrey;
        WorkbenchRenderer.sprite = WorkbenchGrey;
    }
}
