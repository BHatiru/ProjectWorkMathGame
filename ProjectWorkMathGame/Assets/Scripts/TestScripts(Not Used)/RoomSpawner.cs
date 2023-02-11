using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;
    /* Index 1--> need bottom door 
       Index 2--> need top door
       Index 3--> need left door
       Index 4--> need right door */

    private RoomTemplates templates;
    private int rand;
    private bool spawned = false;

    public float waitTime = 4f;
    void Start()
    {
        Destroy(gameObject, waitTime);
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);
    }

   

    void Spawn()
    {

        if(spawned == false)
        {
            if (openingDirection == 1)
            {//Need to spawn a room with a Bottom door
                rand = Random.Range(0, templates.bRooms.Length);
                Instantiate(templates.bRooms[rand], transform.position, templates.bRooms[rand].transform.rotation);

            }
            else if (openingDirection == 2)
            {//Need to spawn a room with a Top door
                rand = Random.Range(0, templates.tRooms.Length);
                Instantiate(templates.tRooms[rand], transform.position, templates.tRooms[rand].transform.rotation);
            }
            else if (openingDirection == 3)
            {//Need to spawn a room with a Left door
                rand = Random.Range(0, templates.lRooms.Length);
                Instantiate(templates.lRooms[rand], transform.position, templates.lRooms[rand].transform.rotation);
            }
            else if (openingDirection == 4)
            {//Need to spawn a room with a Right door
                rand = Random.Range(0, templates.rRooms.Length);
                Instantiate(templates.rRooms[rand], transform.position, templates.rRooms[rand].transform.rotation);
            }
            spawned = true;
        }
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpawnPoint") && other.GetComponent<RoomSpawner>().spawned == true)
        {

            Destroy(gameObject);
        }
    }


}
