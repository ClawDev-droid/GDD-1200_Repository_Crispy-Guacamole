using UnityEngine;
using System.Collections;

public class EnemyLookAtPlayer : MonoBehaviour
{
    public Transform PlayerTransform; // Reference to the player's transform

    // Update is called once per frame
    void Update()
    {
        // get direction of player
        Vector3 dir = transform.position - PlayerTransform.position;
        // get angle of player and convert to degrees        
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        // set rotation of enemy to look at player
        transform.localEulerAngles = new Vector3(0, 0, angle + 90); // Subtract 90 degrees to align with the sprite's forward direction
        // transform.rotation = Quaternion.LookRotation(dir); 
    }
}
