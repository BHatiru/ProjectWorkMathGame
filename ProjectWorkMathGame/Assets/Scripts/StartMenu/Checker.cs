using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checker : MonoBehaviour
{
    public Text pName1, WelcomeText;
    public GameObject NamePanel, Mainmenu, OptionMenu;
    // Start is called before the first frame update
    void Start()
    {
        pName1.text = PlayerPrefs.GetString("name");
        WelcomeText.text = "Welcome " + PlayerPrefs.GetString("name");
        if (!PlayerPrefs.HasKey("FirstTime"))
        {
            NamePanel.SetActive(true);
            Mainmenu.SetActive(false);
            PlayerPrefs.SetInt("FirstTime", 1);
        }
       
    }

}
