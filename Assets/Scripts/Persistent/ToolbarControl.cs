using UnityEditor.UIElements;
using UnityEngine;

public class ToolbarControl : MonoBehaviour
{
    [SerializeField] public RectTransform[] Slots;
    [SerializeField] private RectTransform SelectionFrame;
    public int CurrentIndex;
    private Vector2 TargetPosition;
    private void Start()
    {
        if (Slots.Length > 0)
        {
            SelectionFrame.position = Slots[0].position;
            TargetPosition = Slots[0].position;
        }
    }
    private void Update()
    {
        SelectionFrame.position = Vector2.Lerp(SelectionFrame.position, TargetPosition, 10 * Time.deltaTime);

        if (Input.GetButtonDown("ToolbarLeft"))
        {
            MoveSelection(-1);
        }
        if (Input.GetButtonDown("ToolbarRight"))
        {
            MoveSelection(1);
        }
    }

    private void MoveSelection(int Direction)
    {
        if (Slots.Length == 0)
        {
            return;
        }
        CurrentIndex += Direction;

        if (CurrentIndex < 0)
        {
            CurrentIndex = Slots.Length - 1;
        }
        if (CurrentIndex >= Slots.Length)
        {
            CurrentIndex = 0;
        }
        TargetPosition = Slots[CurrentIndex].position;
    }
    public int GetSelectedIndex()
    {
        return CurrentIndex;
    }
}
