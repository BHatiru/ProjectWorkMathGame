using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Test
public class VictoryTrigger : MonoBehaviour
{
    public GameObject Victory;
    private GameObject Enemy;
    private GameObject DoorLockers;
    private GameObject Win;

  
    void Update()
    {
        DoorLockers = GameObject.FindGameObjectWithTag("BRDL");
        Win = GameObject.FindGameObjectWithTag("WinButton");
        Enemy = GameObject.FindGameObjectWithTag("Enemy");
        if (Enemy != null)
        {
            DoorLockers.SetActive(true);
        }
        if (Enemy == null)
        {
            DoorLockers.SetActive(false);
        }
        
    }
      
    void OnCollisionEnter2D (Collision2D collision)
    {       
        if (collision.gameObject.tag == "VictoryTrigger" && Enemy == null)
        {
            Win.GetComponent<FastWin>().WinTrig();
            Victory.SetActive(true);
            /*if (!PlayerPrefs.HasKey("Wins"))
            {
                PlayerPrefs.SetInt("Wins", 1);
            }
            else
            {
                PlayerPrefs.SetInt("Wins", PlayerPrefs.GetInt("Wins") + 1);
            }
            Time.timeScale = 0f;*/
           /* if (PlayerPrefs.GetInt("Floorcount") <= 4)
            {
                SceneManager.LoadScene("Level1");
                PlayerPrefs.SetInt("FloorCount", PlayerPrefs.GetInt("Floorcount") + 1);
            }
            else
            {
                SceneManager.LoadScene("Level2");
            }   */         
        }               
    }
    //Just for testing purposes, developer tool
   
}