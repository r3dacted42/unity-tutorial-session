using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody rb;
    public float ballForce;
    public float ballMaxSpeed;
    public float ballJumpSpeed;
    public float flyingForce;
    float initSpeed;
    public bool isJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initSpeed = ballForce;
    }

    // Update is called once per frame
    void Update()
    {
        // forward
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(new Vector3(0, 0, ballForce));
        }
        // backward
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(new Vector3(0, 0, -ballForce));
        }
        // right
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(new Vector3(ballForce, 0, 0));
        }
        // left
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(new Vector3(-ballForce, 0, 0));
        }

        // checking max vel
        var velocityInXZPlane = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        if (velocityInXZPlane.sqrMagnitude > ballMaxSpeed * ballMaxSpeed)
        {
            rb.velocity = velocityInXZPlane.normalized * ballMaxSpeed + new Vector3(0, rb.velocity.y, 0);
        }

        // jump
        if (!isJumping && Input.GetKey(KeyCode.Space))
        {
            isJumping = true;
            ballForce = flyingForce;
            rb.velocity = new Vector3(rb.velocity.x, ballJumpSpeed, rb.velocity.z);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isJumping = false;
        ballForce = initSpeed;
    }
}
