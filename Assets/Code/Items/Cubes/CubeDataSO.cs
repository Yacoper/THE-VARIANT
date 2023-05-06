using UnityEngine;

public abstract class CubeDataSO : ScriptableObject
{
    [field: SerializeField] public float Cooldown { get; private set; }
}
