using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalToGameLevel : MonoBehaviour
{
    public GameObject LevelChooser;
    private void OnCollisionEnter2D(Collision2D coll)
    {
        LevelChooser.SetActive(true);//shows panel where player chooses level
       
    }
    public void Level1()
    {
        PlayerPrefs.SetInt("stageCount", 1);
        SceneManager.LoadScene("Level1"); //loading of the corresponding scene of level
    }
    public void Level2()
    {
        PlayerPrefs.SetInt("stageCount", 1);
        SceneManager.LoadScene("Level2"); //loading of the corresponding scene of level
    }
}
