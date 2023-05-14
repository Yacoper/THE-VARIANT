using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private int ActiveOptions = 0;
    [SerializeField] private GameObject Options;
    [SerializeField] private GameObject[] AdvancedOptions;
    [SerializeField] private GameObject LoadingScreen;

    public void PlayGame()
    {
        try { LoadingScreen.SetActive(true); }
        catch
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void OpenOptions(int x = 0)
    {
        switch (++ActiveOptions)
        {
            case 1:
                Options.SetActive(true);
                break;
            case 2:
                AdvancedOptions[x].SetActive(true);
                break;
        }
    }

    public void Back()
    {
        if (ActiveOptions == 0) return;
        switch (--ActiveOptions)
        {
            case 0:
                Options.SetActive(false);
                break;
            case 1:
                foreach (GameObject option in AdvancedOptions)
                    option.SetActive(false);
                break;
        }
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
