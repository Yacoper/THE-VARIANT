using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerItemsInteraction : MonoBehaviour
{
    [Header("InputReader")]
    [SerializeField] private InputReader inputReader;
    
    [Header("Player Settings")]
    [SerializeField] private PlayerPickUpDropSettingsSO values;
    
    [Header("Transform References")]
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private Transform pickUpTargetTransform;

    private PlayerBuffController playerBuffController;
    private PlayerAnimController playerAnimController;

    private PlayerMovement playerMovement;
    private PlayerLook playerLook;
    
    private Cube cube;
    private PickUpItem item;
    private bool hasItemInHand;

    private void Awake()
    {
        playerBuffController = GetComponent<PlayerBuffController>();
        playerAnimController = GetComponent<PlayerAnimController>();

        playerMovement = GetComponent<PlayerMovement>();
        playerLook = GetComponent<PlayerLook>();
    }

    private void OnEnable()
    {
        inputReader.PickUpDropAction += HandlePickUpDropAction;
    }

    private void OnDisable()
    {
        inputReader.PickUpDropAction -= HandlePickUpDropAction;
    }
    
    private void HandlePickUpDropAction(InputAction.CallbackContext callbackContext)
    {
        if(!hasItemInHand)
            TryPickUp();
        else
            TryDrop();
    }

    private void TryPickUp()
    {
        if (!Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit,
                values.PickUpDistance, values.PickUpItemsLayerMask)) return;


        if (raycastHit.collider.CompareTag("Cube"))
        {
            PickUpCube(raycastHit);
        }
        else
        {
            PickUpItem(raycastHit);
        }
    }

    private void PickUpCube(RaycastHit raycastHit)
    {
        StartCoroutine(FreezePlayerForCubePickUp());
        cube = raycastHit.transform.GetComponent<Cube>();
        cube.PickUp(pickUpTargetTransform);
        playerBuffController.SetBuffAvailable(cube.BuffType, cube.CubeData);
        playerAnimController.PlayGrabCubeAnim();
        hasItemInHand = true;
    }
    
    private void PickUpItem(RaycastHit raycastHit)
    {
        item = raycastHit.transform.GetComponent<PickUpItem>();
        item.PickUp(pickUpTargetTransform);
        hasItemInHand = true;
    }

    private void TryDrop()
    {
        if (cube == null)
        {
            item.Drop();
            item = null;
        }
        else
        {
            playerBuffController.ClearBuff(cube.BuffType);
            playerAnimController.PlayDropCubeAnim();
            cube.Drop();
            cube = null;
        }

        hasItemInHand = false;
    }

    private IEnumerator FreezePlayerForCubePickUp()
    {
        playerMovement.enabled = false;
        playerLook.enabled = false;
        yield return new WaitForSeconds(2.5f);
        playerMovement.enabled = true;
        playerLook.enabled = true;
    }

    private void OnValidate()
    {
        ValidateUtilities.NullCheckVariable(this, nameof(inputReader), inputReader, true);
        ValidateUtilities.NullCheckVariable(this, nameof(values), values, true);
        ValidateUtilities.NullCheckVariable(this, nameof(playerCameraTransform), playerCameraTransform, true);
        ValidateUtilities.NullCheckVariable(this, nameof(pickUpTargetTransform), pickUpTargetTransform, true);
    }
}
