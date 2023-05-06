using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Cubes/RedCubeData", fileName = "RedCubeData")]
public class RedCubeDataSO : CubeDataSO
{
    [field: SerializeField] public LayerMask MoveableObjectLayerMask { get; private set; }
    [field: SerializeField] public float ForwardForce { get; private set; }
    [field: SerializeField] public float UpwardForce { get; private set; }
    [field: SerializeField] public float MaxDistancePush { get; private set; }
}
