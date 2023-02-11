using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public GameObject LoadingScreen;
    public Slider slider;
    public Text ProgressPersentage;
    //change to game scene
    public void PlayGame(int SceneIndex)
    {
        StartCoroutine(LoadAsync(SceneIndex));
    }
    

    //Quiting the game
    public void ExitGame()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
    //coroutine for scene loading and activastion of loading screen
    IEnumerator LoadAsync(int SceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneIndex);

        LoadingScreen.SetActive(true);
        while (operation.isDone == false)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            slider.value = progress;
            ProgressPersentage.text = progress * 100f + "%";
            yield return null;
        }//filling progress bar
    }
}
