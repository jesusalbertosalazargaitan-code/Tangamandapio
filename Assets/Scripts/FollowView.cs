using UnityEngine;

public class FollowView : MonoBehaviour
{
    public Transform player;
    
    void FixedUpdate()
    {
        transform.LookAt(player);
    }
}
