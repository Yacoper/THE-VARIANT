using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VoiceTrigger : MonoBehaviour
{
    public SOVoice soVoice;

    public TextMeshProUGUI voiceLineUI;
    public TextMeshProUGUI characterNameUI;

    public AudioSource voiceLine;
    public GameObject voiceLineBaner;

    private static bool isCurrentlyPlaying = false;
    private Queue<SOVoice> soVoiceArray;

    void Start()
    {
        voiceLineUI.text = String.Empty;
        soVoiceArray = new Queue<SOVoice> ();
    }

    void OnTriggerEnter(Collider other)
    {
        if (!isCurrentlyPlaying)
        {
            if (other.tag == "Player")
            {
                gameObject.GetComponent<BoxCollider>().enabled = false;
                MonologSystem(soVoice);
            }
        }
        else
        {
             gameObject.GetComponent<BoxCollider>().enabled = false;
             soVoiceArray.Enqueue(soVoice);
        }
    }

    void Update()
    {
        if (soVoiceArray.Count > 0 && !isCurrentlyPlaying)
        {
            MonologSystem(soVoiceArray.Dequeue());
        }
    }

    void MonologSystem(SOVoice sov)
    {
        isCurrentlyPlaying = true;
        voiceLineBaner.SetActive(true);
        voiceLine.clip = sov.voiceRecord;
        characterNameUI.text = sov.character;
        StartMonologTyping(sov);
        voiceLine.Play();
    }

    void StartMonologTyping(SOVoice sov)
    {
        StartCoroutine(TypeLine(sov));
    }
    IEnumerator TypeLine(SOVoice sov)
    {
        foreach (char c in sov.voiceLineText.ToCharArray())
        {
            voiceLineUI.text += c;
            yield return new WaitForSeconds(soVoice.duration);
        }
        yield return new WaitForSeconds(4);
        voiceLineUI.text = String.Empty;
        voiceLineBaner.SetActive(false);
        isCurrentlyPlaying = false;
    }
}
