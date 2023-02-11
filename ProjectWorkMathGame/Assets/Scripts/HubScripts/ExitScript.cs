using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitScript : MonoBehaviour
{
    public GameObject player;
    private void OnCollisionEnter2D(Collision2D coll)
    {        
        StartCoroutine(ExitFall());     
    }
    IEnumerator ExitFall()
    {
        player.GetComponent<SpriteRenderer>().enabled = false;
        player.GetComponent<Rigidbody2D>().gravityScale = 2;
        player.GetComponent<PlayerMovementAndAim>().enabled = false;
        player.GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(1.7f);
        player.GetComponent<SpriteRenderer>().enabled = true;
        player.GetComponent<Rigidbody2D>().gravityScale = 0;
        player.GetComponent<BoxCollider2D>().enabled = true;
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene("Menu");
    }
}//Script in which if the player enters the abyss then falls and at the end of the fall takes the user to the main menu from Livingroom scene
