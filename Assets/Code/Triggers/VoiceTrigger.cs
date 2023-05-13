using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class VoiceTrigger : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] private InputReader inputReader;

    public SOVoice[] soVoice;

    public TextMeshProUGUI voiceLineUI;
    public TextMeshProUGUI characterNameUI;

    public AudioSource voiceLine;
    public GameObject voiceLineBaner;

    private static bool isCurrentlyPlaying = false;
    private Queue<SOVoice> soVoiceArray;

    private void OnEnable()
    {
        inputReader.SkipDialogueAction += OnSkipDialogueAction;
    }

    private void OnSkipDialogueAction(InputAction.CallbackContext obj)
    {
        StopAllCoroutines();
        voiceLine.Stop();
        voiceLineUI.text = String.Empty;
        voiceLineBaner.SetActive(false);
        isCurrentlyPlaying = false;
    }

    private void OnDisable()
    {
        inputReader.SkipDialogueAction -= OnSkipDialogueAction;
    }
    void Start()
    {
        voiceLineUI.text = String.Empty;
        soVoiceArray = new Queue<SOVoice>();
    }

    void OnTriggerEnter(Collider other)
    {
        foreach (SOVoice voice in soVoice)
        {
            if (!isCurrentlyPlaying)
            {
                if (other.CompareTag("Player"))
                {
                    gameObject.GetComponent<BoxCollider>().enabled = false;
                    MonologSystem(voice);
                }
            }
            else
            {
                gameObject.GetComponent<BoxCollider>().enabled = false;
                soVoiceArray.Enqueue(voice);
            }
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
            yield return new WaitForSeconds(sov.duration);
        }
        yield return new WaitForSeconds(sov.breakAfter);
        voiceLineUI.text = String.Empty;
        voiceLineBaner.SetActive(false);
        isCurrentlyPlaying = false;
    }
}
