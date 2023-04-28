using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class VoiceTrigger : MonoBehaviour
{
    public SOVoice soVoice;
    public TextMeshProUGUI voiceLineUI;
    public TextMeshProUGUI characterNameUI;
    public AudioSource voiceLine;
    public GameObject voiceLineBaner;
    void Start()
    {
        voiceLineUI.text = String.Empty;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            voiceLineBaner.SetActive(true);
            voiceLine.clip = soVoice.voiceRecord;
            characterNameUI.text = soVoice.character;
            StartMonologTyping();
            voiceLine.Play();
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
    void StartMonologTyping()
    {
        StartCoroutine(TypeLine());
    }
    IEnumerator TypeLine()
    {
        foreach (char c in soVoice.voiceLineText.ToCharArray())
        {
            voiceLineUI.text += c;
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(4);
        voiceLineUI.text = String.Empty;
        voiceLineBaner.SetActive(false);
    }
}
