using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactions : MonoBehaviour
{
    public static PlayerInput PlayerInput;

    public static bool WasInteractPressed;

    private InputAction _InteractionAction;
    
    private void Awake()
    {
        PlayerInput = GetComponent<PlayerInput>();


        _InteractionAction = PlayerInput.actions["Interact"];
    }

    private void Update()
    {
        WasInteractPressed = _InteractionAction.WasPressedThisFrame();
    }
}
