using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    internal Rigidbody rb;
    public float horizontal, vertical;
    public float speed = 5f;
    public bool moving = false;
    Vector3 startPosition = Vector3.zero;
    public Vector3 direction;
    public Vector3 velocity;

    public void PlayerStart()
    {
        transform.position = startPosition;
        rb = GetComponent<Rigidbody>();
    }

    public void PlayerUpdate()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        direction = new Vector3(horizontal, 0f, vertical);
        Move(direction);
    }

    void Move(Vector3 direction)
    {
        if (direction != Vector3.zero)
        {
            direction = direction.normalized;
            moving = true;
        }
        else
        {
            moving = false;
        }
        velocity = new Vector3(direction.x * speed, rb.velocity.y, direction.z * speed);
        rb.velocity = velocity;
    }
}
