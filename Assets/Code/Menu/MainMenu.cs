using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private int ActiveOptions = 0;
    [SerializeField] private GameObject Options;
    [SerializeField] private GameObject[] AdvancedOptions;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OpenOptions()
    {
        ActiveOptions++;
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
                foreach(GameObject option in AdvancedOptions)
                    option.SetActive(false);
                break;
        }
    }



    public void QuitGame()
    {
        Application.Quit();
    }
}
