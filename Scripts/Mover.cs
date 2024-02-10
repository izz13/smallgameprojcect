using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    internal Rigidbody rb; //declare rigid body object
    public float horizontal, vertical; // declare variables which store horizontal and vertical value
    public float speed = 5f; // set speed 
    public bool moving = false; // declare variable that tracks movement of the body
    Vector3 startPosition = Vector3.zero; // set start position as (0, 0, 0)
    public Vector3 direction; //declare variable stores x, y, z vector values of direction
    public Vector3 velocity; //declare variable stores x, y, z vector values of velocity

    public void PlayerStart() // method which operates when the game starts
    {
        transform.position = startPosition; // set the position as the start position which is (0,0,0)
        rb = GetComponent<Rigidbody>(); //set the main body object as the rigid body
    }

    public void PlayerUpdate() // method which update the movement based on the user's input
    {
        horizontal = Input.GetAxisRaw("Horizontal"); //set the horizontal value according to the input of the right and left arrow key
        vertical = Input.GetAxisRaw("Vertical"); // set the vertical value according to the input of the up and down arrow key
        direction = new Vector3(horizontal, 0f, vertical); // set the direction of the body according to the value stored in horizontal and vertical variable
        Move(direction); // then call move function by giving direction as parameter (which makes movement to the object according to the value in the direction variable)
    }

    void Move(Vector3 direction) //method which move the object
    {
        if (direction != Vector3.zero) // check whetehr there is value in the direction variable
        {
            direction = direction.normalized; // if there is value, then normalized the direction (normalized makes the object to move in the same speed regrardless the direction)
            moving = true; // then trigger the moving variable to true
        }
        else // if there is no value in direction variable, then
        {
            moving = false; // trigger the moving variable to false
        }
        velocity = new Vector3(direction.x * speed, rb.velocity.y, direction.z * speed); // calculate the velocity according to the value in the direction variable
        rb.velocity = velocity; // update the rigid body velocity to the value in the velocity variable
    }
}
