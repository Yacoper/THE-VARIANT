using DG.Tweening;
using UnityEngine;

public class Cube : PickUpAbleItem
{
    public BuffTypes BuffType
    {
        get => buffType;
        set => buffType = value;
    }
    
    public CubeDataSO CubeData
    {
        get => cubeData;
        set => cubeData = value;
    }
    
    [SerializeField] private BuffTypes buffType;
    [SerializeField] private CubeDataSO cubeData;
    [SerializeField] private float desiredTime = 2f;
    [SerializeField] private Vector3 desiredScale = new Vector3(0.5f, 0.5f, 0.5f);


    public override void PickUp(Transform pickUpTargetTransform)
    {
        Transform cubeTransform = transform;
        
        itemTargetTransform = pickUpTargetTransform;
        itemRigidbody.isKinematic = true;

        cubeTransform.parent = itemTargetTransform;
        transform.DOScale(desiredScale, desiredTime);
        transform.DOMove(pickUpTargetTransform.position, desiredTime);
    }

    public override void Drop()
    {
        transform.parent = null;
        itemTargetTransform = null;
        itemRigidbody.isKinematic = false;
        transform.DOScale(Vector3.one * 3f, 1f);
    }

    
    private void OnValidate()
    {
        ValidateUtilities.NullCheckVariable(this, nameof(buffType), buffType, true);
        ValidateUtilities.NullCheckVariable(this, nameof(cubeData), cubeData, true);
        ValidateUtilities.NullCheckVariable(this, nameof(desiredTime), desiredTime, true);
    }
}
