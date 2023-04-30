using System;
using Unity.VisualScripting;
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

    private PlayerMovement playerMovement;
    private Cube cube;
    private PickUpItem item;
    
    private bool hasItemInHand;
    private BuffTypes currentBuff;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
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
        cube = raycastHit.transform.GetComponent<Cube>();
        cube.PickUp(pickUpTargetTransform);
        currentBuff = cube.BuffType;
        ApplyBuff();
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
            ClearBuff();
            cube.Drop();
            cube = null;
        }

        hasItemInHand = false;
    }

    private void ApplyBuff()
    {
        switch (currentBuff)
        {
            case BuffTypes.None:
                break;
            case BuffTypes.RedBuff:
                break;
            case BuffTypes.GreenBuff:
                playerMovement.HasGreenBuff = true;
                break;
            case BuffTypes.BlueBuff:
                playerMovement.HasBlueBuff = true;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void ClearBuff()
    {
        switch (currentBuff)
        {
            case BuffTypes.RedBuff:
                break;
            case BuffTypes.GreenBuff:
                playerMovement.HasGreenBuff = false;
                break;
            case BuffTypes.BlueBuff:
                playerMovement.HasBlueBuff = false;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        currentBuff = BuffTypes.None;
    }

    private void OnValidate()
    {
        ValidateUtilities.NullCheckVariable(this, nameof(inputReader), inputReader, true);
        ValidateUtilities.NullCheckVariable(this, nameof(values), values, true);
        ValidateUtilities.NullCheckVariable(this, nameof(playerCameraTransform), playerCameraTransform, true);
        ValidateUtilities.NullCheckVariable(this, nameof(pickUpTargetTransform), pickUpTargetTransform, true);
    }
}
