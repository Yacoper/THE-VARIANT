using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] private InputReader inputReader;
    [SerializeField] private GameObject PauseVisual;
    [SerializeField] private GameObject OptionsVisual;
    private bool Paused = false;
    private int Options = 0;

    private void OnEnable()
    {
        PauseVisual.SetActive(false);
        inputReader.PauseGameAction += Pause;
    }

    private void Pause(InputAction.CallbackContext callbackContext) => Pause();

    public void Pause()
    {
        if(Options > 0)
        {
            switch(--Options)
            {
                case 0:
                    OptionsVisual.SetActive(false);
                    break;
                case 1:
                    break;
            }
            return;
        }
        Paused = !Paused;
        PauseVisual.SetActive(Paused);
        Cursor.visible = true;
        if (Paused)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;
    }

    public void Resume()
    {
        OpenOptions(false);
        Pause();
    }

    public void OpenOptions(bool open)
    {
        if(!open)
        {
            Options = 0;
            OptionsVisual.SetActive(false);
            return;
        }
        switch(Options)
        {
            case 0:
                Options++;
                OptionsVisual.SetActive(true);
                break;
            case 1:
                Options = 0;
                OptionsVisual.SetActive(false);
                break;
        }
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
