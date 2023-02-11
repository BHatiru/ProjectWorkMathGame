using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebTest : MonoBehaviour
{
    
    IEnumerator Start()
    {
        WWW request = new WWW("http://localhost/sqlconnect/webtest.php");
            yield return request;
        string[] webRequests = request.text.Split('\t');
        
    }

  
}
//NOT USED