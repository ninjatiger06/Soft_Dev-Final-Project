using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementWSAD : MonoBehaviour
{

    public float moveSpeed = 5f;

    //Create physics object
    public Rigidbody2D rb;

    //Create movement vector
    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        //Get mouse input for every frame
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        //Move the ship depending on the keyboard input at a set speed
        rb.MovePosition(rb.position + movement * moveSpeed * (Time.fixedDeltaTime*2));

        //Flip the spaceship
        Vector3 spaceshipScale = transform.localScale;
        if (Input.GetAxis("Horizontal") < 0)
        {
            spaceshipScale.x = -1;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            spaceshipScale.x = 1;
        }
        transform.localScale = spaceshipScale;
    }
}
