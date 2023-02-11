using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool PauseState = false;

    public GameObject PauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseState)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        PauseState = false;
    }
    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        PauseState = true;
    }
    public void ReturnStartMenu()
    {
        Time.timeScale = 1f;
        Debug.Log("Return to start menu...");
        SceneManager.LoadScene("Menu");       
        

    }
    public void ReturnLiveRoom()
    {
        Time.timeScale = 1f;
        DungeonCrawlerController.positionsVisited.Clear();
        SceneManager.LoadScene("LivingRoom");
    }
    public void NextStage()
    {
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            if (PlayerPrefs.GetInt("stageCount") < 4)
            {
                PlayerPrefs.SetInt("stageCount", PlayerPrefs.GetInt("stageCount") + 1);
                Time.timeScale = 1f;
                DungeonCrawlerController.positionsVisited.Clear();
                SceneManager.LoadScene("Level1");            
            }
            else
            {
                PlayerPrefs.SetInt("stageCount", 1);
                ReturnLiveRoom();
            }
        }
        if (SceneManager.GetActiveScene().name == "Level2")
        {
            if (PlayerPrefs.GetInt("stageCount") < 3)
            {
                PlayerPrefs.SetInt("stageCount", PlayerPrefs.GetInt("stageCount") + 1);
                Time.timeScale = 1f;
                DungeonCrawlerController.positionsVisited.Clear();
                SceneManager.LoadScene("Level2");
            }
            else
            {
                PlayerPrefs.SetInt("stageCount", 1);
                ReturnLiveRoom();
            }
        }

         
    }
    public void ExitGame()
    {
        Debug.Log("Exit game...");
        Application.Quit();
    }
}
