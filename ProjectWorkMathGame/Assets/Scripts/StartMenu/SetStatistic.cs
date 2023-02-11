using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetStatistic : MonoBehaviour
{
    public Text Win,Lose;
    string Name;
    int Wins,Losses;
    void Start()
    {      
        Win.text = "Wins: " + PlayerPrefs.GetInt("Wins").ToString();
        Lose.text = "Loses: " + PlayerPrefs.GetInt("Loses").ToString();
        StartCoroutine(SavePlayerData());

    }
    public void CallSaveData()
    {
        StartCoroutine(SavePlayerData());
    }
    IEnumerator SavePlayerData()
    {
        Name = PlayerPrefs.GetString("name");
        Wins = PlayerPrefs.GetInt("Wins");
        Losses = PlayerPrefs.GetInt("Loses");
        WWWForm form1 = new WWWForm();
        form1.AddField("name1", Name);
        form1.AddField("wins", Wins);
        form1.AddField("losses", Losses);


        WWW www = new WWW("http://localhost/sqlconnect/savedata.php", form1);
        yield return www;
        //Debug.Log(www.text);         //PlayerPrefs.GetString("ID")
        if (www.text == "0")
        {
            Debug.Log("player data saved");
        }
        else
        {
            Debug.Log("Save failed. Error #" + www.text);
        }
    } // saves game statistics of player wins/losses in the game itself and in the database.
}
