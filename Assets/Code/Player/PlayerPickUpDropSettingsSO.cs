using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPickUpDropSettings", menuName = "ScriptableObjects/Player/PlayerPickUpDropSettings")]
public class PlayerPickUpDropSettingsSO : ScriptableObject
{
    [field: SerializeField] public LayerMask PickUpItemsLayerMask { get; private set; }
    [field: SerializeField] public float PickUpDistance { get; private set; }
}
