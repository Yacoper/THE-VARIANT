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
    private PickUpItem pickUpItem;

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
        if(pickUpItem == null)
            TryPickUp();
        else
            TryDrop();
    }

    private void TryPickUp()
    {
        if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit,
                values.PickUpDistance, values.PickUpItemsLayerMask))
        {
            if (raycastHit.transform.TryGetComponent(out pickUpItem))
            {
                pickUpItem.PickUp(pickUpTargetTransform);
            }
        }
    }

    private void TryDrop()
    {
        pickUpItem.Drop();
        pickUpItem = null;
    }

    private void OnValidate()
    {
        ValidateUtilities.NullCheckVariable(this, nameof(inputReader), inputReader, true);
        ValidateUtilities.NullCheckVariable(this, nameof(pickUpDropSettings), pickUpDropSettings, true);
        ValidateUtilities.NullCheckVariable(this, nameof(playerCameraTransform), playerCameraTransform, true);
        ValidateUtilities.NullCheckVariable(this, nameof(pickUpTargetTransform), pickUpTargetTransform, true);
    }
}
