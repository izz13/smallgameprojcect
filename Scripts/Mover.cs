using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    internal Rigidbody rb; //declare rigid body object
    public float horizontal, vertical; // declare variables which store horizontal and vertical value
    public float verticalSpeed = 5f; // set speed
    public float horizontalSpeed = 5f;
    public bool moving = false; // declare variable that tracks movement of the body
    public float jumpHeight = 5f;
    Vector3 startPosition = Vector3.zero; // set start position as (0, 0, 0)
    public Vector3 direction; //declare variable stores x, y, z vector values of direction
    public Vector3 velocity; //declare variable stores x, y, z vector values of velocity
    bool desiredJump; // declare variable that tracks whether the body wants to jump or not in the boolean data type
    bool onGround; // declare variable that tracks whether the body is on the ground or not in boolean data type.
    public bool playerReset;
    public bool playerHitGeneratePlatform;

    LayerMask mask;

    public float distanceFromEdge;

    public void PlayerStart() // method which operates when the game starts
    {
        transform.position = startPosition; // set the position as the start position which is (0,0,0)
        rb = GetComponent<Rigidbody>(); //set the main body object as the rigid body
        mask = LayerMask.GetMask("GeneratePlatform");
    }

    public void PlayerUpdate() // method which update the movement based on the user's input
    {
        horizontal = Input.GetAxisRaw("Horizontal"); //set the horizontal value according to the input of the right and left arrow key
        // vertical = Input.GetAxisRaw("Vertical"); // set the vertical value according to the input of the up and down arrow key
        vertical = verticalSpeed;
        direction = new Vector3(horizontal, 0f, vertical); // set the direction of the body according to the value stored in horizontal and vertical variable
        // Move(direction); // then call move function by giving direction as parameter (which makes movement to the object according to the value in the direction variable)
        desiredJump |= Input.GetButtonDown("Jump");
        offMap();
        playerHitGeneratePlatform = CheckEdge();//if the ray hit the generatePlatform trigger, then turn the playerHitGeneratePlatform to be True;
    }

    void offMap()
    {
        if (this.transform.position.y < -10)
        {
            playerReset = true;
        }
    }

    public void Move() //method which move the object
    {
        if (direction != Vector3.zero) // check whetehr there is value in the direction variable
        {
            //direction = direction.normalized; // if there is value, then normalized the direction (normalized makes the object to move in the same speed regrardless the direction)
            moving = true; // then trigger the moving variable to true
        }
        else // if there is no value in direction variable, then
        {
            moving = false; // trigger the moving variable to false
        }
        if (desiredJump)
        {
            desiredJump = false;
            Jump();
        }
        velocity = new Vector3(direction.x * horizontalSpeed, rb.velocity.y, direction.z * verticalSpeed); // calculate the velocity according to the value in the direction variable
        rb.velocity = velocity; // update the rigid body velocity to the value in the velocity variable
        onGround = false;
    }
    void Jump()
    {
        if (onGround)
        {
            float jumpVelocity = Mathf.Sqrt(-2f * Physics.gravity.y * jumpHeight);
            rb.velocity += Vector3.up * jumpHeight;
        }
    }
    void OnCollisionStay(Collision collision)
    {
        EvaluateCollision(collision);
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        EvaluateCollision(collision);
    }
    void EvaluateCollision(Collision collision)
    {
        for(int i = 0; i < collision.contactCount; i++)
        {
            Vector3 normal = collision.GetContact(i).normal;
            if(normal.y >= 0.9f)
            {
                onGround = true;
            }
            else
            {
                playerReset = true;
            }
        }
    }
    bool CheckEdge()//this function shoots a ray from the player's position with a direction of the player's forward vector and checks if it hits a platform generator
    {
        //A ray is a "infinite" line that shoots out from a given position with a given direction
        Ray ray = new Ray(transform.position, transform.forward);//shooting a ray from the player's position with a direction fo the player's forward vector
        if (Physics.Raycast(ray, out RaycastHit hitInfo, 50f, mask))//Checking if the ray has hit a collider that has a mask GeneratePlatform
        {
            distanceFromEdge = hitInfo.point.z - transform.position.z;//getting the distance between the player and the collider that was hit
            Destroy(hitInfo.collider.gameObject);//destroying the game object that the ray hit
            return true;
        }
        else
        {
            return false;
        }
    }
}
