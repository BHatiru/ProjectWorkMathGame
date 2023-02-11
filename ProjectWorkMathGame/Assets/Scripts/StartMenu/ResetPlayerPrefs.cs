using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetPlayerPrefs : MonoBehaviour
{  
    public void Resetbutton()
    {        
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }
}// script that resets all preferences
