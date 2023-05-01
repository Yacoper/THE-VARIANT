using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRedCubePower : MonoBehaviour
{
    [SerializeField] private InputReader inputReader;
    
    public BuffTypes CurrentBuffAvailable 
    { 
        get => currentBuffAvailable;
        set => currentBuffAvailable = value;
    }

    public bool IsBuffApplied
    {
        get => isBuffApplied;
        set => isBuffApplied = value;
    }
    
    private BuffTypes currentBuffAvailable;
    private bool isBuffApplied;
    
    private void OnEnable()
    {
        inputReader.UseCube += ToggleBuff;
    }

    private void OnDisable()
    {
        inputReader.UseCube -= ToggleBuff;
    }
    
    private void ToggleBuff(InputAction.CallbackContext callbackContext)
    {
        if(currentBuffAvailable == BuffTypes.None)
            return;

        isBuffApplied = !isBuffApplied;
    }

    private void OnValidate()
    {
        ValidateUtilities.NullCheckVariable(this, nameof(inputReader), inputReader, true);
    }
}
