using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactions : MonoBehaviour
{
    public static PlayerInput PlayerInput;

    public static bool IsHolding;
    public static bool WasInteractPressed;
    public static bool WasInteractReleased;

    private InputAction _InteractionAction;
    
    private void Awake()
    {
        PlayerInput = GetComponent<PlayerInput>();


        _InteractionAction = PlayerInput.actions["Interact"];
    }

    private void Update()
    {
        WasInteractPressed = _InteractionAction.WasPressedThisFrame();
        WasInteractReleased = _InteractionAction.WasReleasedThisFrame();
        //mine/pickup-hold interaction
        _InteractionAction.performed += HoldPerformed;
        _InteractionAction.canceled += HoldCanceled;
    }

    private void HoldCanceled(InputAction.CallbackContext context)
    {
        IsHolding = false;
        Debug.Log("Canceled");
    }

    private void HoldPerformed(InputAction.CallbackContext context)
    {
        IsHolding = true;
        Debug.Log("Holding");
    }

    public bool GetHolding()
    {
        return IsHolding;
    }
}
