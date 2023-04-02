using UnityEngine;

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
}
