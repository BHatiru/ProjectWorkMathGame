using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FastWin : MonoBehaviour
{
    public GameObject Victory;
    public GameObject Timer;
    public GameObject Player;

    public void WinTrig()
    {
        if (SceneManager.GetActiveScene().name == "Level1") // 
        {
            StartCoroutine(SaveLevel1Data());
            if (PlayerPrefs.GetInt("stageCount") == 4)
            {
                if (!PlayerPrefs.HasKey("Wins"))
                {
                    PlayerPrefs.SetInt("Wins", 1);
                }
                else
                {
                    PlayerPrefs.SetInt("Wins", PlayerPrefs.GetInt("Wins") + 1);
                }
            }
        }
        if (SceneManager.GetActiveScene().name == "Level2")
        {
            StartCoroutine(SaveLevel2Data());
            if (PlayerPrefs.GetInt("stageCount") == 3)
            {
                if (!PlayerPrefs.HasKey("Wins"))
                {
                    PlayerPrefs.SetInt("Wins", 1);
                }
                else
                {
                    PlayerPrefs.SetInt("Wins", PlayerPrefs.GetInt("Wins") + 1);
                }
            }
        }/*determines which level is currently running and depending on this launches different 
        methods and changes the number of floors that the player must pass*/

        Victory.SetActive(true); // Victory panel
        Time.timeScale = 0f;
      

    }

    public IEnumerator SaveLevel1Data()
    {
        WWWForm form1 = new WWWForm();
        form1.AddField("name1", PlayerPrefs.GetString("name"));
        form1.AddField("EnemyKilled", Player.GetComponent<Shooting>().KillCount);
        form1.AddField("Time", Timer.GetComponent<Timer>().textTimer.text);        //writes the necessary data to a form that uses a php file and writes it to a table
        WWW www = new WWW("http://localhost/sqlconnect/savelevel1data.php", form1);      //request to our php file  
        yield return www;
        //Debug.Log(www.text);         //PlayerPrefs.GetString("ID")
        if (www.text == "0")
        {
            Debug.Log("game data saved");
        }
        else
        {
            Debug.Log("Save failed. Error #" + www.text);
        }

    }
    public IEnumerator SaveLevel2Data()
    {
        WWWForm form1 = new WWWForm();
        form1.AddField("name1", PlayerPrefs.GetString("name"));
        form1.AddField("EnemyKilled", Player.GetComponent<Shooting>().KillCount);
        form1.AddField("Time", Timer.GetComponent<Timer>().textTimer.text);        //same as above
        WWW www = new WWW("http://localhost/sqlconnect/savelevel2data.php", form1);
        yield return www;
        //Debug.Log(www.text);         //PlayerPrefs.GetString("ID")
        if (www.text == "0")
        {
            Debug.Log("game data saved");
        }
        else
        {
            Debug.Log("Save failed. Error #" + www.text);
        }

    }
}
