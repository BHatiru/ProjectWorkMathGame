using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HelpCloud : MonoBehaviour
{
    public GameObject HintText;


    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            HintText.SetActive(true);
        }
    }
    void OnCollisionExit2D(Collision2D coll)
    {
        
        if (coll.gameObject.tag == "Player")
        {
            HintText.SetActive(false);
        }
    }

}
