using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    [SerializeField] private GameObject loadingCanvas;
    [SerializeField] private Slider progressBar;

    private AsyncOperation sceneToLoad;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public async void LoadScene(string sceneName)
    {
        sceneToLoad = SceneManager.LoadSceneAsync(sceneName);
        sceneToLoad.allowSceneActivation = true;
        
        loadingCanvas.SetActive(true);

        while (sceneToLoad.progress < 0.9f)
        {
            await Task.Delay(1000);
            progressBar.value = sceneToLoad.progress *1.1111f;
        }
        
        await Task.Delay(1000);
        loadingCanvas.SetActive(false);
    }
}
