using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Finite-State Machine

public enum EnemyState
{
    Idle,
    Wander,
    Follow,
    Die
};
public class EnemyController : MonoBehaviour
{
    GameObject player;

    public EnemyState currState = EnemyState.Idle;

    public float range;

    public float speed;

    private bool chooseDir = false;
    private bool dead = false;

    private Vector3 randomDir;

    public bool notInRoom = false;
 

    void Start()
    {
        //reference
        
        player = GameObject.FindGameObjectWithTag("Player");
    }
 
    void Update()
    {       
        switch (currState)
        {
            case (EnemyState.Idle):
                Idle();
                break;
            case (EnemyState.Wander):
                Wander();
                break;
            case (EnemyState.Follow):
                Follow();
                break;
            case (EnemyState.Die):                
                Death();
                break;
        }
        //states conditions
        if (!notInRoom)
        {
            if (isPlayerInRange(range) && currState != EnemyState.Die)
            {
                currState = EnemyState.Follow;
            }
            else if (!isPlayerInRange(range) && currState != EnemyState.Die)
            {
                currState = EnemyState.Wander;
            }
        }
        else
        {
            currState = EnemyState.Idle;
        }
    }
    //enemies detection range
    private bool isPlayerInRange(float range)
    {
        return Vector3.Distance(transform.position, player.transform.position) <= range;
    }
    //random direction chooser fo wander state
    private IEnumerator ChooseDirection()
    {
        chooseDir = true;
        yield return new WaitForSeconds(Random.Range(2f, 4f));
        randomDir = new Vector3(0, 0, Random.Range(0, 360));
        Quaternion nextRotation = Quaternion.Euler(randomDir);
        transform.rotation = Quaternion.Lerp(transform.rotation, nextRotation, Random.Range(0.5f, 2.5f));
        chooseDir = false;
    }
    //method for wander state
    void Wander()
    {
        speed = 2f;
        if (!chooseDir)
        {
            StartCoroutine(ChooseDirection());
        }
        //move
        transform.position += -transform.right * speed * Time.deltaTime;
        if (isPlayerInRange(range))
        {
            currState = EnemyState.Follow;
        }
    }


    //method for follow state
    void Follow()
    {
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            speed = 1.5f;
        }
        if (SceneManager.GetActiveScene().name == "Level2")
        {
            speed = 1f;
        }
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);        
    }
    //method for idle state
    public void Idle()
    {
        
    }
    //method for death state
    public void Death()
    {
        player.GetComponent<PlayerHealth>().IsCollided = false;
        RoomController.instance.StartCoroutine(RoomController.instance.RoomCoroutine());
        Destroy(gameObject);
    }
}
