using UnityEngine;

public abstract class PickUpItem : MonoBehaviour
{
    private Rigidbody itemRigidbody;
    private Transform itemTargetTransform;
    private Collider itemCollider;

    private void Awake()
    {
        itemRigidbody = GetComponent<Rigidbody>();
        itemCollider = GetComponent<Collider>();
    }

    private void FixedUpdate()
    {
        float lerpSpeed = 100f;
        if (itemTargetTransform != null)
        {
            Vector3 newPosition = Vector3.Lerp(transform.position, itemTargetTransform.transform.position,
                lerpSpeed * Time.fixedDeltaTime);
            itemRigidbody.MovePosition(newPosition);
        }
    }

    public void PickUp(Transform pickUpTargetTransform)
    {
        itemTargetTransform = pickUpTargetTransform;
        itemRigidbody.isKinematic = true;
        itemCollider.enabled = false;
    }

    public void Drop()
    {
        itemTargetTransform = null;
        itemRigidbody.isKinematic = false;
        itemCollider.enabled = true;
    }
}
