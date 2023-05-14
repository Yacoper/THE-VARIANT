using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private Slider ProgressBar;
    private AsyncOperation LoadLevel;

    private void OnEnable()
    {
        LoadLevel = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void Update()
    {
        ProgressBar.value = LoadLevel.progress;
    }
}
