using System;
using UnityEngine;

public class BreakableItem : MonoBehaviour
{
    [SerializeField] private GameObject wholeObject;
    [SerializeField] private GameObject brokenObject;

    private BoxCollider boxCollider;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.transform.CompareTag("MoveableObject"))
            return;

        if (collision.relativeVelocity.magnitude < 7f)
            return;

        boxCollider.enabled = false;
        wholeObject.SetActive(false);
        brokenObject.SetActive(true);
        Destroy(this);
    }
}
