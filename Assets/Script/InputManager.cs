using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static event System.Action<Vector2> OnMovement;
    public static event System.Action<bool> OnJump;
    public static event System.Action<bool> OnEscape;

    [SerializeField] private PlayerInput playerInput;

    private void OnEnable()
    {
        playerInput.onActionTriggered += HandleInput;
    }

    private void OnDisable()
    {
        playerInput.onActionTriggered -= HandleInput;
    }


    private void HandleInput( InputAction.CallbackContext context)
    {
        string action = context.action.name;

        switch (action)
        {
            case "Movimiento":
                Vector2 inputs = context.ReadValue<Vector2>();
                OnMovement?.Invoke(inputs);
                break;

            case "Salto":
                bool salto =  context.ReadValueAsButton();
                OnJump?.Invoke(salto);
                break;
        }
    }
    
}
