using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRestarter : MonoBehaviour
{
    public void RestartGameLevel(int SceneIndex)
    {
        //restart scene
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneIndex);
    }
}
