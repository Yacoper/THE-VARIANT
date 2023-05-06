using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Cubes/GreenCubeData", fileName = "GreenCubeData")]
public class GreenCubeDataSO : CubeDataSO
{
    [field: SerializeField] public float BuffDuration { get; private set; }
    [field: SerializeField] public float PlayerSpeedMultiplier { get; private set; }
}
