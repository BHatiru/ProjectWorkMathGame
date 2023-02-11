using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SaveName : MonoBehaviour
{
    public Text pName1,pName2, WelcomeText;
    public InputField nameBox;
    public Button accept;
    public GameObject NamePanel, Mainmenu, OptionMenu;

    private void Update()
    {
        accept.interactable = (nameBox.text.Length <= 16 && nameBox.text.Length >= 1);
    }

    public void RegistrName() // public method so it can be used in another place(button) 
    {
        StartCoroutine(RegName());
    }
    public void ChangeName()
    {
        StartCoroutine(changeName());
    }

    IEnumerator changeName()
    {
        int ID = 41;
        PlayerPrefs.SetString("name", nameBox.text);
        pName1.text = PlayerPrefs.GetString("name");
        pName2.text = "Welcome " + PlayerPrefs.GetString("name");
        if (!PlayerPrefs.HasKey("FirstTime"))
        {
            NamePanel.SetActive(false);
            Mainmenu.SetActive(true);
            PlayerPrefs.SetInt("FirstTime", 1);
        }
        else
        {
            NamePanel.SetActive(false);
            OptionMenu.SetActive(true);
        }

        WWWForm form2 = new WWWForm();
        form2.AddField("name", nameBox.text);
        form2.AddField("Id", PlayerPrefs.GetString("ID"));
        WWW www1 = new WWW("http://localhost/sqlconnect/changename.php", form2);
        yield return www1;
        if (www1.text == "0")
        {
            Debug.Log("User change name succesfully");
            //UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        else
        {
            Debug.Log("User change failed. Error #" + www1.text);
        }
    } // method for changing the name. it doesn't work correctly

    IEnumerator RegName()
    {
        PlayerPrefs.SetString("name", nameBox.text);
       
        if (!PlayerPrefs.HasKey("FirstTime"))
        {
            NamePanel.SetActive(false);
            Mainmenu.SetActive(true);
            PlayerPrefs.SetInt("FirstTime", 1);
        }

        WWWForm form = new WWWForm();
        form.AddField("name", nameBox.text);
        WWW www2 = new WWW("http://localhost/sqlconnect/register.php", form); //connection to webpage
        yield return www2;
        
        if (www2.text == "0")
        {
            Debug.Log("User registered succesfully");
            pName1.text = PlayerPrefs.GetString("name");
            WelcomeText.text = "Welcome " + PlayerPrefs.GetString("name");
            NamePanel.SetActive(false);
            Mainmenu.SetActive(true);
        }
        else
        {
            Debug.Log("User registration failed. Error #" + www2.text);
            nameBox.text = "Name taken";
            Debug.Log("Name taken");
        }
        
    }/*the method for registering a name */

    public void VerifyInputs()
    {
        accept.interactable = (nameBox.text.Length <= 16 && nameBox.text.Length >= 1);
    }//length verification

}
