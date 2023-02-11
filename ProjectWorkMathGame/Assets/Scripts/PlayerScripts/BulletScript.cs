using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
     
    void Start()
    {
        StartCoroutine(DeathDelay()); 
    }

    IEnumerator DeathDelay()
    {
         yield return new WaitForSeconds(1.5f);
         Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            col.gameObject.GetComponent<EnemyController>().Death();
            
            Destroy(gameObject);
        }
        if (col.tag == "Wall")
        {        
            Destroy(gameObject);
        }
    }
}
