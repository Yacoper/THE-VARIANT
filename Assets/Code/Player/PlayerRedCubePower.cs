using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRedCubePower : MonoBehaviour, IApplyBuffFromCube
{
    public CubeDataSO CurrentCubeData { get; set; }

    [SerializeField] private InputReader inputReader;
    [SerializeField] private Transform playerCameraTransform;

    [SerializeField] private LayerMask moveableObjectLayerMask;

    public BuffTypes CurrentBuffAvailable { get; set; }

    public bool IsBuffApplied { get; set; }

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

    public void ApplyBuffFromCube(BuffTypes buffType, CubeDataSO cubeData)
    {
        throw new System.NotImplementedException();
    }
}
