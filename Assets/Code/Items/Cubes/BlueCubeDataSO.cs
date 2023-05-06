using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Cubes/BlueCubeData", fileName = "BlueCubeData")]
public class BlueCubeDataSO : CubeDataSO
{
    [field: SerializeField] public float BuffDuration { get; private set; }
    [field: SerializeField] public float JumpForceMultiplier { get; private set; }
}
