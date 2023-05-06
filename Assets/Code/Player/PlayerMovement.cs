using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour, IApplyBuffFromCube
{
    [Header("Input")]
    [SerializeField] private InputReader inputReader;
    [Header("Player Settings")]
    [SerializeField] private PlayerMovementSettingsSO values;
    
    private CharacterController characterController;
    private Vector3 moveDir;
    private Vector3 yVelocity;
    
    private bool isGrounded;
    private bool isBuffApplied;

    private BuffTypes currentBuffAvailable;
    private BlueCubeDataSO blueCubeData;
    private GreenCubeDataSO greenCubeData;

    private void OnEnable()
    {
        inputReader.JumpAction += Jump;
        inputReader.UseCube += ToggleBuff;
    }

    private void OnDisable()
    {
        inputReader.JumpAction -= Jump;
        inputReader.UseCube -= ToggleBuff;
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
    
    public void ApplyBuffFromCube(BuffTypes buffType, CubeDataSO cubeData)
    {
        currentBuffAvailable = buffType;
        
        if(buffType == BuffTypes.GreenBuff)
            greenCubeData = cubeData as GreenCubeDataSO;
        else
            blueCubeData = cubeData as BlueCubeDataSO;
    }

    public void ClearBuffFromCube()
    {
        currentBuffAvailable = BuffTypes.None;
        blueCubeData = null;
        greenCubeData = null;
        isBuffApplied = false;
    }

    private void Jump(InputAction.CallbackContext callbackContext)
    {
        if(!isGrounded)
            return;
        
        float jumpForce = values.JumpForce;

        if (currentBuffAvailable == BuffTypes.BlueBuff && isBuffApplied)
        {
            jumpForce *= blueCubeData.JumpForceMultiplier;
        }

        yVelocity.y = jumpForce;
    }

    private void MovePlayer()
    {
        float playerSpeed = values.PlayerSpeed;

        if (currentBuffAvailable == BuffTypes.GreenBuff && isBuffApplied)
        {
            playerSpeed *= greenCubeData.PlayerSpeedMultiplier;
        }
        
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

    private void ToggleBuff(InputAction.CallbackContext callbackContext)
    {
        if(currentBuffAvailable == BuffTypes.None)
            return;

        isBuffApplied = !isBuffApplied;
    }

    private bool HasHitCeiling()
    {
        RaycastHit hit;
#if UNITY_EDITOR
        Debug.DrawRay(transform.position, Vector3.up * 1.5f, Color.red);
#endif
        return Physics.Raycast(transform.position, Vector3.up, out hit, 1.5f);
    }

    private void OnValidate()
    {
        ValidateUtilities.NullCheckVariable(this, nameof(inputReader), inputReader, true);
        ValidateUtilities.NullCheckVariable(this, nameof(values), values, true);
    }
}
