using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showDataFromTable : MonoBehaviour
{
    public void WebPage()
    {
        StartCoroutine(PlayerData());
    }
    IEnumerator PlayerData()
    {       
        WWW www = new WWW("http://localhost/sqlconnect/showtable.php");
        yield return www;             
    }
}
// NOT USED 