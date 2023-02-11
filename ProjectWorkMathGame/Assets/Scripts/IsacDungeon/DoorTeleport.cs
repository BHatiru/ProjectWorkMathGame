using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTeleport : MonoBehaviour
{
    public Door leftDoor;
    public Door rightDoor;
    public Door topDoor;
    public Door bottomDoor;

    public List<Door> doors = new List<Door>();

    private GameObject player;
    //Need to access the types of doors to determine which way to move the player.
    private void Start()
    {
        Door[] ds = GetComponentsInParent<Door>();
        foreach (Door d in ds)
        {
            doors.Add(d);
            switch (d.doorType)
            {
                case Door.DoorType.right:
                    rightDoor = d;
                    break;
                case Door.DoorType.left:
                    leftDoor = d;
                    break;
                case Door.DoorType.top:
                    topDoor = d;
                    break;
                case Door.DoorType.bottom:
                    bottomDoor = d;
                    break;
            }
        }

        player = GameObject.FindGameObjectWithTag("Player");
    }
    //when collides with a door the player teleports to the room where the door leads
    private void OnTriggerEnter2D(Collider2D other)
    {       
        
        if (other.tag == "Player")
        {
            
            foreach (Door door in doors)
            {
                switch (door.doorType)
                {
                    case Door.DoorType.right:
                        player.transform.position = new Vector2(player.transform.position.x + 1.8f, player.transform.position.y);
                        break;
                    case Door.DoorType.left:
                        player.transform.position = new Vector2(player.transform.position.x - 1.8f, player.transform.position.y);
                        break;
                    case Door.DoorType.top:
                        player.transform.position = new Vector2(player.transform.position.x, player.transform.position.y + 1.8f);
                        break;
                    case Door.DoorType.bottom:
                        player.transform.position = new Vector2(player.transform.position.x, player.transform.position.y - 1.8f);
                        break;
                }
            }
        }        
    }
}
