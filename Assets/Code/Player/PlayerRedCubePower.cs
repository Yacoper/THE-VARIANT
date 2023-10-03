using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRedCubePower : MonoBehaviour, IApplyBuffFromCube
{
    [SerializeField] private InputReader inputReader;
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private GameObject buffCanva;

    private RedCubeDataSO currentCubeData;
    private BuffTypes currentBuffAvailable;
    
    private bool isBuffApplied;
    private bool isOnCooldown;

    private void OnEnable()
    {
        inputReader.UseCubeAction += UseRedCubeAction;
    }

    private void OnDisable()
    {
        inputReader.UseCubeAction -= UseRedCubeAction;
    }
    
    public void ApplyBuffFromCube(BuffTypes buffType, CubeDataSO cubeData)
    {
        currentBuffAvailable = buffType;
        currentCubeData = cubeData as RedCubeDataSO;
        isBuffApplied = true;
        buffCanva.SetActive(true);
        Animator BuffCanvaAnim = buffCanva.GetComponentInChildren<Animator>();
        BuffCanvaAnim.SetTrigger("PlayBuff");
    }

    public void ClearBuffFromCube()
    {
        currentBuffAvailable = BuffTypes.None;
        currentCubeData = null;
        isBuffApplied = false;
        Animator BuffCanvaAnim = buffCanva.GetComponentInChildren<Animator>();
        BuffCanvaAnim.SetTrigger("LeaveBuff");
        buffCanva.SetActive(false);
    }

    private void UseRedCubeAction(InputAction.CallbackContext callbackContext)
    {
        if(isOnCooldown)
            return;
        
        if(!isBuffApplied)
            return;
        
        if(currentBuffAvailable != BuffTypes.RedBuff)
            return;
        
        if (!Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit,
                currentCubeData.MaxDistancePush, currentCubeData.MoveableObjectLayerMask))
            return;

        Vector3 forceToApply = playerCameraTransform.forward * currentCubeData.ForwardForce;
        forceToApply.y = currentCubeData.UpwardForce;
        raycastHit.transform.GetComponent<MoveAbleObject>().MoveObject(forceToApply);
        isOnCooldown = true;

        StartCoroutine(Cooldown(currentCubeData.Cooldown));
    }
    
    private IEnumerator Cooldown(float cooldownTime)
    {
        yield return new WaitForSeconds(cooldownTime);
        isOnCooldown = false;
    }
    
    private void OnValidate()
    {
        ValidateUtilities.NullCheckVariable(this, nameof(inputReader), inputReader, true);
        ValidateUtilities.NullCheckVariable(this, nameof(playerCameraTransform), playerCameraTransform, true);
    }
}
