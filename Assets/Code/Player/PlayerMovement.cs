using System;
using MyBox;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] private InputReader inputReader;
    [Header("Player Settings")]
    [SerializeField] private PlayerSettingsSO playerSettings;
    
    private CharacterController characterController;
    private Vector3 moveDir;
    private Vector3 yVelocity;
    private bool isGrounded;
    
    private float playerSpeed;
    private float jumpForce;
    private float gravityForce;
    private bool hasDrag;
    private float dragValue;

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
        Init();
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

    private void Init()
    {
        playerSpeed = playerSettings.PlayerSpeed;
        jumpForce = playerSettings.JumpForce;
        gravityForce = playerSettings.GravityForce;
        hasDrag = playerSettings.hasDrag;
        dragValue = playerSettings.dragValue;
    }

    private void Jump(InputAction.CallbackContext callbackContext)
    {
        if(!isGrounded)
            return;

        yVelocity.y = jumpForce;
    }

    private void MovePlayer()
    {
        characterController.Move(transform.TransformDirection(moveDir) * (Time.deltaTime * playerSpeed));
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
        
        if (!hasDrag)
        {
            yVelocity.y += gravityForce * Time.fixedDeltaTime;
        }
        else
        {
            yVelocity.y += gravityForce * (1f - dragValue) * Time.fixedDeltaTime;
        }

        yVelocity.y = Math.Clamp(yVelocity.y,-50f, 50f);
        characterController.Move(yVelocity);
    }

    private bool HasHitCeiling()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, Vector3.up * 1.5f, Color.red );
        return Physics.Raycast(transform.position, Vector3.up, out hit, 1.5f);
    }
}
