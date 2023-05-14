using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private int ActiveOptions = 0;
    [SerializeField] private GameObject options;
    [SerializeField] private GameObject[] advancedOptions;

    public void PlayGame(string sceneName)
    {
        LevelManager.Instance.LoadScene(sceneName);
    }

    public void OpenOptions(int x = 0)
    {
        switch (++ActiveOptions)
        {
            case 1:
                options.SetActive(true);
                break;
            case 2:
                advancedOptions[x].SetActive(true);
                break;
        }
    }

    public void Back()
    {
        if (ActiveOptions == 0) return;
        switch (--ActiveOptions)
        {
            case 0:
                options.SetActive(false);
                break;
            case 1:
                foreach (GameObject option in advancedOptions)
                    option.SetActive(false);
                break;
        }
    }
    
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    private void OnValidate()
    {
        ValidateUtilities.NullCheckVariable(this, nameof(options), options, true);
    }
}
