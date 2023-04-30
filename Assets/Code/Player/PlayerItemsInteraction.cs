using System;
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
    private bool hasItemInHand;
    private PickUpAbleItem pickUpAbleItem;

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
        if(pickUpAbleItem == null)
            TryPickUp();
        else
            TryDrop();
    }

    private void TryPickUp()
    {
        if (!Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit,
                values.PickUpDistance, values.PickUpItemsLayerMask)) return;
        
        if (!raycastHit.transform.TryGetComponent(out pickUpAbleItem))
            return;

        if (raycastHit.collider.CompareTag("Cube"))
        {
            PickUpCube();
        }
        else
        {
            PickUpItem();
        }
    }

    private void PickUpCube()
    {
        pickUpAbleItem.GetComponent<Cube>();
        pickUpAbleItem.PickUp(pickUpTargetTransform);
    }
    
    private void PickUpItem()
    {
        pickUpAbleItem.GetComponent<PickUpItem>();
        pickUpAbleItem.PickUp(pickUpTargetTransform);
    }

    private void TryDrop()
    {
        pickUpAbleItem.Drop();
        pickUpAbleItem = null;
    }

    private void OnValidate()
    {
        ValidateUtilities.NullCheckVariable(this, nameof(inputReader), inputReader, true);
        ValidateUtilities.NullCheckVariable(this, nameof(values), values, true);
        ValidateUtilities.NullCheckVariable(this, nameof(playerCameraTransform), playerCameraTransform, true);
        ValidateUtilities.NullCheckVariable(this, nameof(pickUpTargetTransform), pickUpTargetTransform, true);
    }
}
