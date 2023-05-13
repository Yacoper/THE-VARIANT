using UnityEngine;

public abstract class PickUpAbleItem : MonoBehaviour
{
    protected Rigidbody itemRigidbody;
    protected Transform itemTargetTransform;
    protected Collider itemCollider;

    protected virtual void Awake()
    {
        itemRigidbody = GetComponent<Rigidbody>();
        itemCollider = GetComponent<Collider>();
    }

    public virtual void PickUp(Transform pickUpTargetTransform)
    {
        itemTargetTransform = pickUpTargetTransform;
        itemRigidbody.isKinematic = true;
        itemCollider.enabled = false;
    }

    public virtual void Drop()
    {
        itemTargetTransform = null;
        itemRigidbody.isKinematic = false;
        itemCollider.enabled = true;
    }
}
