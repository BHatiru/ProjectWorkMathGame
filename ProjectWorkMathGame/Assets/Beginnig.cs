using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beginnig : MonoBehaviour
{
    public GameObject Mbox;

    private void Start()
    {    
            Mbox.SetActive(true);
            Time.timeScale = 0f;
                
    }
    public void StartGame()
    {

        gameObject.SetActive(false);
        Time.timeScale = 1f;     
    }
}
