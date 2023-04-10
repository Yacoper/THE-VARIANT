using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputReader inputReader;
    [SerializeField] private float playerSpeed = 10f;
    [SerializeField] private float jumpForce = 10f;
    [FormerlySerializedAs("gravityScale")] [SerializeField] private float gravityForce = -9.81f;
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
        Debug.Log(yVelocity);
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
            yVelocity.y = -2f;
        }
        yVelocity.y = Math.Clamp(yVelocity.y,-50f, 50f);
        characterController.Move(yVelocity);
    }
}
