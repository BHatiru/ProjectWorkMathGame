using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public GameObject LoadingScreen;
    public Slider slider;
    public Text ProgressPersentage;

    public void LoadLevel(int SceneIndex)
    {
        StartCoroutine(LoadAsync(SceneIndex));
        
    }
    IEnumerator LoadAsync (int SceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneIndex);

        LoadingScreen.SetActive(true);
        while (operation.isDone == false)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            slider.value = progress;
            ProgressPersentage.text = progress * 100f + "%";

            yield return null;
        }
    }
}
