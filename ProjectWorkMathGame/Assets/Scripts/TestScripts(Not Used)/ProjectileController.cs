using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float lifeTime;
    void Start()
    {

        //StartCoroutine(DeathDelay()); 
    }

   /* IEnumerator DeathDelay()
    {

        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }*/

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Enemy")
        {
            col.gameObject.GetComponent<EnemyController>().Death();
            Destroy(gameObject);
        }
    }
}//NOT USED
