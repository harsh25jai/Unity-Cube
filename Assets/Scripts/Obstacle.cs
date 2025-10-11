using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Obstacle : MonoBehaviour
{
    public Rigidbody rb;

    int forwardForce = 2000;
    public float destroyPosition = -2f;
    int score;
   

    private void Update()
    {
        if (transform.position.y < destroyPosition)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        score = FindFirstObjectByType<ScoreManager>().GetScore();
        forwardForce = FindFirstObjectByType<ScoreManager>().UpdateForwardForce(score);
        // Adding a forword force to the Rigidbody
        rb.AddForce(0, 0, -forwardForce * Time.deltaTime);
    }
}
