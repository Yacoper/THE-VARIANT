using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAbleObject : MonoBehaviour
{
    private Rigidbody objectRigidbody;

    private void Awake()
    {
        objectRigidbody = GetComponent<Rigidbody>();
    }

    public void MoveObject(Vector3 appliedForce)
    {
        objectRigidbody.AddForce(appliedForce);
    }
}
