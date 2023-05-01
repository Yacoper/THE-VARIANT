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

    private PlayerBuffController playerBuffController;
    private Cube cube;
    private PickUpItem item;
    
    private bool hasItemInHand;

    private void Awake()
    {
        playerBuffController = GetComponent<PlayerBuffController>();
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
        playerBuffController.ApplyBuff(cube.BuffType);
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
            cube.Drop();
            cube = null;
        }

        hasItemInHand = false;
    }

    private void OnValidate()
    {
        ValidateUtilities.NullCheckVariable(this, nameof(inputReader), inputReader, true);
        ValidateUtilities.NullCheckVariable(this, nameof(values), values, true);
        ValidateUtilities.NullCheckVariable(this, nameof(playerCameraTransform), playerCameraTransform, true);
        ValidateUtilities.NullCheckVariable(this, nameof(pickUpTargetTransform), pickUpTargetTransform, true);
    }
}
