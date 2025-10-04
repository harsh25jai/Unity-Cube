using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Rigidbody rb;

    int forwardForce = 2000;
    public float destroyPosition = -2f;
   

    private void Update()
    {
        if (transform.position.y < destroyPosition)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        forwardForce = FindFirstObjectByType<GameManager>().ObstacleForwardForce();
        // Adding a forword force to the Rigidbody
        rb.AddForce(0, 0, -forwardForce * Time.deltaTime);
    }
}
