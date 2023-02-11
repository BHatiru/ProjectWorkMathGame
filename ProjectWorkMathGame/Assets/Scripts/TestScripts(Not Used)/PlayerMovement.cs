using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//NOT USED.
public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator anime;

    public Joystick moveJoystick;
    public Joystick shootJoystock;

    public GameObject projectilePrefab;
    public float projectileSpeed;
    private float lastFire;
    public float fireDelay;

    void Start()
    {
        //references
        anime = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        //movement occurs only when the joystick is shifted sufficiently
        change = Vector3.zero;
        if (moveJoystick.Horizontal >= 0.2f || moveJoystick.Horizontal <= -0.2f)
        {
            change.x = moveJoystick.Horizontal;
        }
        if (moveJoystick.Vertical >= 0.2f || moveJoystick.Vertical <= -0.2f)
        {
            change.y = moveJoystick.Vertical;
        }

        float shootHor=0;
        float shootVer=0;
        if (shootJoystock.Horizontal >= 0.2f || shootJoystock.Horizontal <= -0.2f)
        {
            shootHor = shootJoystock.Horizontal;
        }
        if (shootJoystock.Vertical >= 0.2f || shootJoystock.Vertical <= -0.2f)
        {
            shootVer = shootJoystock.Vertical;
        }
        if ((shootHor !=0 || shootVer != 0) && Time.time > lastFire + fireDelay)
        {
            Shoot(shootHor,shootVer);
            lastFire = Time.time;
        }

        //change.x = Input.GetAxisRaw("Horizontal");
        //change.y = Input.GetAxisRaw("Vertical");        
        UpdateAnimationAndMove();
    }
    //Animation updating method
    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            anime.SetFloat("MoveX", change.x);
            anime.SetFloat("MoveY", change.y);
            anime.SetBool("Moving", true);
        }
        else
        {
            anime.SetBool("Moving", false);
        }

    }

    //method for actual player movement
    void MoveCharacter()
    {
        myRigidbody.MovePosition(transform.position + change * speed * Time.deltaTime);
    }

    void Shoot(float x, float y)
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation) as GameObject;
        projectile.AddComponent<Rigidbody2D>().gravityScale = 0;
        projectile.GetComponent<Rigidbody2D>().velocity = new Vector3(
            (x < 0) ? Mathf.Floor(x) * projectileSpeed : Mathf.Ceil(x) * projectileSpeed,
            (y < 0) ? Mathf.Floor(y) * projectileSpeed : Mathf.Ceil(y) * projectileSpeed,
            0);
    }
}//NOT USED. Replaced with a more compact and lightweight method of movement
