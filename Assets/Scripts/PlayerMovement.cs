using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public int forwardForce = 500;
    public int sidewaysForce = 500;

    // Update is called once per frame
    void FixedUpdate()
    {
        // Adding a forword force to the Rigidbody
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        float x = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * sidewaysForce;
        rb.AddForce(x, 0, 0, ForceMode.VelocityChange);

        if(rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
