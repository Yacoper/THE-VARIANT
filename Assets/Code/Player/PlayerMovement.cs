using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] private InputReader inputReader;
    [Header("Player Settings")]
    [SerializeField] private PlayerMovementSettingsSO values;
    
    private CharacterController characterController;
    private Vector3 moveDir;
    private Vector3 yVelocity;
    private bool isGrounded;
    
    private void OnEnable()
    {
        inputReader.JumpAction += Jump;
    }

    private void OnDisable()
    {
        inputReader.JumpAction -= Jump;
    }

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        isGrounded = characterController.isGrounded;
    }

    private void FixedUpdate()
    {
        GetMoveDirection(inputReader.GetMoveVector());
        MovePlayer();
        ApplyGravity();
    }

    private void Jump(InputAction.CallbackContext callbackContext)
    {
        if(!isGrounded)
            return;

        yVelocity.y = values.JumpForce;
    }

    private void MovePlayer()
    {
        characterController.Move(transform.TransformDirection(moveDir) * (Time.deltaTime * values.PlayerSpeed));
    }

    private void GetMoveDirection(Vector2 input)
    {
        moveDir.x = input.x;
        moveDir.z = input.y;
    }

    private void ApplyGravity()
    {
        if (isGrounded && yVelocity.y < 0)
        {
            yVelocity.y = -0.1f;
        }

        if (HasHitCeiling())
        {
            yVelocity.y = -0.03f;
        }
        
        if (!values.hasDrag)
        {
            yVelocity.y += values.GravityForce * Time.fixedDeltaTime;
        }
        else
        {
            yVelocity.y += values.GravityForce * (1f - values.dragValue) * Time.fixedDeltaTime;
        }

        yVelocity.y = Math.Clamp(yVelocity.y,-50f, 50f);
        characterController.Move(yVelocity);
    }

    private bool HasHitCeiling()
    {
        RaycastHit hit;
#if UNITY_EDITOR
        Debug.DrawRay(transform.position, Vector3.up * 1.5f, Color.red );
#endif
        return Physics.Raycast(transform.position, Vector3.up, out hit, 1.5f);
    }
}
