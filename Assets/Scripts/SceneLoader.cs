using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;

public class SceneLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider loadingSlider;
    private AsyncOperation operation;
    private static SceneLoader _instance;

    public static SceneLoader Instance
    {
        get
        {
            return _instance;
        }
    }

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else 
        {
            _instance = this;
		}
    }

    void OnEnable()
    {
        DontDestroyOnLoad(this);
    }

    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadLevelAsynchrounously(sceneIndex));
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
        EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }

    IEnumerator LoadLevelAsynchrounously(int sceneIndex)
    {
        Debug.Log("Loading new scene!");
        operation = SceneManager.LoadSceneAsync(sceneIndex);
        float progress = 0;
        loadingScreen.SetActive(true);
        while(!operation.isDone)
        {
            progress = Mathf.Clamp01(operation.progress/0.9f);
            loadingSlider.value = progress;
            Debug.Log(progress);
            yield return null;
        }
    }

}
