using System;
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

    private void OnValidate()
    {
        ValidateUtilities.NullCheckVariable(this, nameof(buffType), buffType, true);
        ValidateUtilities.NullCheckVariable(this, nameof(cubeData), cubeData, true);
    }
}
