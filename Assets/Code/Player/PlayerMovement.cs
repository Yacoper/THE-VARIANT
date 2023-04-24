using System;
using MyBox;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] private InputReader inputReader;
    [Header("Player Setting")]
    [SerializeField] private float playerSpeed = 10f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float gravityForce = -9.81f;
    public bool hasDrag;
    [ConditionalField("hasDrag")] public float dragValue = 10f;
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
        Debug.Log(dragValue);
    }

    private void FixedUpdate()
    {
        GetMoveDirection(inputReader.GetMoveVector());
        MovePlayer();
        ApplyGravity();
        //Debug.Log(yVelocity);
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
        yVelocity.y += gravityForce * Time.fixedDeltaTime;
        if (isGrounded && yVelocity.y < 0)
        {
            yVelocity.y = -0.1f;
        }
        yVelocity.y = Math.Clamp(yVelocity.y,-50f, 50f);
        characterController.Move(yVelocity);
    }
}
