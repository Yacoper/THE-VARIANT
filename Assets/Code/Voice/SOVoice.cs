using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "New Voice", menuName = "VoiceLine")]
public class SOVoice : ScriptableObject
{
    public string voiceLineText;
    public AudioClip voiceRecord;
    public float duration;
    public string character;
}
