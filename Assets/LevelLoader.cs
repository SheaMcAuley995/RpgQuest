using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class LevelLoader : MonoBehaviour {

    #region singleton

    public static LevelLoader instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;

    public void LoadLevel(string sceneName)
    {
        StartCoroutine(loadAsynchronously(sceneName));
    }

    IEnumerator loadAsynchronously(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        loadingScreen.SetActive(true);

        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            slider.value = progress;
            progressText.text = progress * 100f + "%";

            yield return null;
        }
    }

}
