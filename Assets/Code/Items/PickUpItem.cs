using UnityEngine;

public abstract class PickUpItem : MonoBehaviour
{
    private Rigidbody itemRigidbody;
    private Transform itemTargetTransform;

    private void Awake()
    {
        itemRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float lerpSpeed = 10f;
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
    }

    public void Drop()
    {
        itemTargetTransform = null;
        itemRigidbody.isKinematic = false;
    }
}
