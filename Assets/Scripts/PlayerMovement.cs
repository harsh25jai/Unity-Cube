using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public int sidewaysForce = 500;
    public bool movement = true;
    public NewGameManager gameManager;

    // Update is called once per frame
    void FixedUpdate()
    {
        // Time.DeltaTime firstFrame -> SecoundFrame
        if (movement)
        {
            float x = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * sidewaysForce;
            rb.AddForce(x, 0, 0, ForceMode.VelocityChange);

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.position.x < Screen.width / 2)
                {
                    float l = -1 * Time.fixedDeltaTime * sidewaysForce;
                    rb.AddForce(l, 0, 0, ForceMode.VelocityChange);
                }
                else if (touch.position.x > Screen.width / 2)
                {
                    float r = 1 * Time.fixedDeltaTime * sidewaysForce;
                    rb.AddForce(r, 0, 0, ForceMode.VelocityChange);
                }
            }
        }

        if (rb.position.y < -1f)
        {
            gameManager.EndGame();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            movement = false;
            //Destroy(GameObject.FindWithTag("Obstacle"));

            gameManager.EndGame();
        }
    }
}
