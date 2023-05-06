using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRedCubePower : MonoBehaviour, IApplyBuffFromCube
{
    [SerializeField] private InputReader inputReader;
    [SerializeField] private Transform playerCameraTransform;

    [SerializeField] private LayerMask moveableObjectLayerMask;

    private RedCubeDataSO currentCubeData;
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
    
    public void ApplyBuffFromCube(BuffTypes buffType, CubeDataSO cubeData)
    {
        currentBuffAvailable = buffType;
        currentCubeData = cubeData as RedCubeDataSO;
        isBuffApplied = true;
    }

    public void ClearBuffFromCube()
    {
        currentBuffAvailable = BuffTypes.None;
        currentCubeData = null;
        isBuffApplied = false;
    }
    
    private void UseRedCube(InputAction.CallbackContext callbackContext)
    {
        if(!isBuffApplied)
            return;
        
        if (!Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit,
                5f, currentCubeData.MoveableObjectLayerMask))
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
