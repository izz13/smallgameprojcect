using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    internal Rigidbody rb;
    public float horizontal, vertical;
    public float speed = 5f;
    public bool moving = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical);
        Move(direction);
    }

    void Move(Vector3 direction)
    {
        if (direction != Vector3.zero)
        {
            direction.Normalize();
            moving = true;
        }
        else
        {
            moving = false;
        }
        direction.y = rb.velocity.y;
        rb.velocity = direction * speed;
    }
}
