using UnityEngine;

public class PickUpItem : PickUpAbleItem
{
    private void FixedUpdate()
    {
        const float lerpSpeed = 10f;
        if (itemTargetTransform == null)
            return;
        if(Vector3.Distance(transform.position, itemTargetTransform.position) < 0.01f)
            return;
        
        Vector3 newPosition = Vector3.Lerp(transform.position, itemTargetTransform.transform.position,
            lerpSpeed * Time.fixedDeltaTime);
        itemRigidbody.MovePosition(newPosition);
    }
}
