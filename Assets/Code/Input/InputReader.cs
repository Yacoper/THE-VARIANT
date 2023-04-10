using System;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "InputReader", menuName = "ScriptableObjects/Input/InputReader")]
public class InputReader : ScriptableObject
{
    private GameInput gameInput;

    private void OnEnable()
    {
        if (gameInput == null)
        {
            gameInput = new GameInput();
        }

        gameInput.Gameplay.Enable();
    }

    private void OnDisable()
    {
        gameInput.Gameplay.Disable();
    }

    public Vector2 GetMoveVector()
    {
        return gameInput.Gameplay.Move.ReadValue<Vector2>();
    }

    public Vector2 GetLookInput()
    {
        return gameInput.Gameplay.Look.ReadValue<Vector2>();
    }
    
    public event Action<InputAction.CallbackContext> JumpAction
    {
        add => gameInput.Gameplay.Jump.performed += value;
        remove => gameInput.Gameplay.Jump.performed -= value;
    }
}
