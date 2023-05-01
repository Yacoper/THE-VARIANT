using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRedCubePower : MonoBehaviour
{
    [SerializeField] private InputReader inputReader;
    [SerializeField] private Transform playerCameraTransform;

    [SerializeField] private LayerMask moveableObjectLayerMask;
    
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
        inputReader.UseCube += UseRedCube;
    }

    private void OnDisable()
    {
        inputReader.UseCube -= UseRedCube;
    }
    
    private void UseRedCube(InputAction.CallbackContext callbackContext)
    {
        if (!Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit,
                5f, moveableObjectLayerMask))
            return;

        Vector3 forceToApply = playerCameraTransform.forward * 1000f;
        forceToApply.y = 100f;
        raycastHit.transform.GetComponent<MoveAbleObject>().MoveObject(forceToApply);
    }

    private void OnValidate()
    {
        ValidateUtilities.NullCheckVariable(this, nameof(inputReader), inputReader, true);
        ValidateUtilities.NullCheckVariable(this, nameof(playerCameraTransform), playerCameraTransform, true);
    }
}
