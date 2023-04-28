using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerItemsInteraction : MonoBehaviour
{
    [Header("InputReader")]
    [SerializeField] private InputReader inputReader;
    
    [Header("Player Settings")]
    [SerializeField] private PlayerPickUpDropSettingsSO pickUpDropSettings;
    
    [Header("Transform References")]
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private Transform pickUpTargetTransform;

    private PlayerMovement playerMovement;
    private bool hasItemInHand;
    private PickUpItem pickUpItem;

    private float pickUpDistance;
    private LayerMask pickUpItemsLayerMask;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        Init();
    }

    private void OnEnable()
    {
        inputReader.PickUpDropAction += HandlePickUpDropAction;
    }

    private void OnDisable()
    {
        inputReader.PickUpDropAction -= HandlePickUpDropAction;
    }

    private void Init()
    {
        pickUpDistance = pickUpDropSettings.PickUpDistance;
        pickUpItemsLayerMask = pickUpDropSettings.PickUpItemsLayerMask;
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
                pickUpDistance, pickUpItemsLayerMask))
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

}
