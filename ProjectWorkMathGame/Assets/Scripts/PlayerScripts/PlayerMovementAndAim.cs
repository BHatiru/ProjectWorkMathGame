using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementAndAim : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Joystick moveJoystick;

    private Vector2 movement;
    private Animator anime;
   

    void Start()
    {
        //reference
        anime = GetComponent<Animator>();
        
    }
    void Update()
    {      
        movement = Vector2.zero;
        if (moveJoystick.Horizontal >= 0.2f || moveJoystick.Horizontal <= -0.2f)
        {
            movement.x = moveJoystick.Horizontal;
        }
        if (moveJoystick.Vertical >= 0.2f || moveJoystick.Vertical <= -0.2f)
        {
            movement.y = moveJoystick.Vertical;
        } // connecting the player's movement with the joystick movement

        UpdateAnimationAndMove();
    }

    void UpdateAnimationAndMove() //changes the player's animation to match their movement
    {
        if (movement != Vector2.zero)
        {
            MoveCharacter();
            anime.SetFloat("MoveX", movement.x);
            anime.SetFloat("MoveY", movement.y);
            anime.SetBool("Moving", true);
        }
        else
        {
            anime.SetBool("Moving", false);
        }

    }

    void MoveCharacter()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);//actual moving
    }
}
