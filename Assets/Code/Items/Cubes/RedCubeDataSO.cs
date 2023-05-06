using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Cubes/RedCubeData", fileName = "RedCubeData")]
public class RedCubeDataSO : CubeDataSO
{
    [field: SerializeField] public LayerMask MoveableObjectLayerMask { get; private set; }
}
