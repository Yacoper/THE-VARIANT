using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGesture : MonoBehaviour
{
    [SerializeField] private InputReader inputReader;
    private PlayerAnimController playerAnimController;

    private void OnEnable()
    {
        inputReader.FingerGunAction += OnFingerGunAction;
        inputReader.HandFuckAction += OnHandFuckAction;
    }

    private void OnDisable()
    {
        inputReader.FingerGunAction -= OnFingerGunAction;
        inputReader.HandFuckAction -= OnHandFuckAction;
    }

    private void Awake()
    {
        playerAnimController = GetComponent<PlayerAnimController>();
    }

    private void OnHandFuckAction(InputAction.CallbackContext obj)
    {
        playerAnimController.PlayHandFuckAnim();
    }

    private void OnFingerGunAction(InputAction.CallbackContext obj)
    {
        playerAnimController.PlayFingerGunAnim();
    }

    private void OnValidate()
    {
        ValidateUtilities.NullCheckVariable(this, nameof(inputReader), inputReader, true);
    }
}
