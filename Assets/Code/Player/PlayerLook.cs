using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private InputReader inputReader;
    [SerializeField] private CinemachineVirtualCamera playerCamera;
    [SerializeField] private float xSensitivity = 20f;
    [SerializeField] private float ySensitivity = 20f;

    private float upDownRotation;
    private float lookX;
    private float lookY;

    private void LateUpdate()
    {
        GetInput(inputReader.GetLookInput());
        CameraLookUpAndDown();
        RotatePlayerOnXAxis();
    }

    private void GetInput(Vector2 lookInput)
    {
        lookX = lookInput.x;
        lookY = lookInput.y;
    }

    private void CameraLookUpAndDown()
    {
        upDownRotation -= (lookY * Time.deltaTime) * ySensitivity;
        upDownRotation = Math.Clamp(upDownRotation, -70f, 70f);
        playerCamera.transform.localRotation = Quaternion.Euler(upDownRotation, 0f, 0f);
    }

    private void RotatePlayerOnXAxis()
    {
        transform.Rotate(Vector3.up * (lookX * Time.deltaTime * xSensitivity));
    }
    
}
