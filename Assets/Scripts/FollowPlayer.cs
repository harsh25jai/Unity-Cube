using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 playerOffset;
   
    // Update is called once per frame
    void Update()
    {
        transform.position = player.position - playerOffset;        
    }
}
