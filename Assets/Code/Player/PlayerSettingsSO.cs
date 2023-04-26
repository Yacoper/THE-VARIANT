using System.Collections;
using System.Collections.Generic;
using MyBox;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Settings", menuName = "ScriptableObjects/Player/PlayerSettings")]
public class PlayerSettingsSO : ScriptableObject
{
    [field: SerializeField] [Tooltip("Speed of the player")] public float PlayerSpeed { get; private set; } = 8f;
    [field: SerializeField] [Tooltip("Force add when player jump")] public float JumpForce { get; private set; } = 0.4f;
    [field: SerializeField] [Tooltip("Gravity force applied to player, need to be negative")] public float GravityForce { get; private set; } = -1f;
    [Tooltip("Enables drag")] public bool hasDrag;
    [ConditionalField("hasDrag")] [Range(0.0f, 1.0f)] [Tooltip("Decreases the drag by the given percentage.")] public float dragValue = 0.05f;
}
