using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] private InputReader inputReader;
    [SerializeField] private GameObject PauseVisual;
    private bool paused = false;

    private void OnEnable()
    {
        PauseVisual.SetActive(false);
        inputReader.PauseGameAction += Pause;
    }

    private void Pause(InputAction.CallbackContext callbackContext)
    {
        paused = !paused;
        PauseVisual.SetActive(paused);
        if(paused)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;
    }

}
