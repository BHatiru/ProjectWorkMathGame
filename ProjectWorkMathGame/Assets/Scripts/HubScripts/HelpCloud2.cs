using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpCloud2 : MonoBehaviour
{
    public GameObject HintText2;


    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            HintText2.SetActive(true);
        }
    }
    void OnCollisionExit2D(Collision2D coll)
    {

        if (coll.gameObject.tag == "Player")
        {
            HintText2.SetActive(false);
        }
    }
}
