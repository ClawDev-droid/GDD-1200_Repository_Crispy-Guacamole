using UnityEngine;

public class SpaceJunkMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 1f; // Speed at which the space junk moves
    public Vector2 moveDirection = Vector2.down; // Direction in which the space junk moves
    [Header("Rotation")]
    public float RotationSpeed = 90f; // Speed at which the space junk rotates

    [Header("Lifecycle")]
    public float areaBounds = 15f;
        //if (transform.position.x < -screenBounds.x || transform.position.x > screenBounds.x ||
          //  transform.position.y < -screenBounds.y || transform.position.y > screenBounds.y)

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // move object
        transform.Translate(moveDirection * (moveSpeed * Time.deltaTime), Space.World);
         
        // rotate object
        transform.Rotate(Vector3.forward, RotationSpeed * Time.deltaTime);

        
    }

    void onBecameInvisible()
    {
        CheckOutOfBounds();
    }


    private void CheckOutOfBounds()
    {
        var dist = Vector3.Distance(Camera.main.transform.position, transform.position);


        if (dist > areaBounds)
        {
            Destroy(gameObject);
        }
    }
}
