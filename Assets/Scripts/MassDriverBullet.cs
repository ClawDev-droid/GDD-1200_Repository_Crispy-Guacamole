using UnityEngine;



public class MassDriverBullet : MonoBehaviour
{
    public float speed = 100f; // Speed of the bullet
    public float lifetime = 5f; // Time before the bullet is destroyed
    public Rigidbody2D _rb;

    public float minSpeed = 10f; // Minimum speed before the bullet disapears

    private void Start()
    {
        // Destroy the bullet after its lifetime expires
        //Destroy(gameObject, lifetime);
        //b.AddForce(Vector3.up * speed * Time.deltaTime, ForceMode2D.Impulse);
        _rb.AddForce(transform.up * speed, ForceMode2D.Impulse);
    }

    private void awake()
    {
        // Set the bullet's velocity to move forward
        
        Destroy(gameObject, 5f);
        
        
       
    }

    private void Update()
    {
        if (_rb == null)
        {
            _rb = GetComponent<Rigidbody2D>();
        }
        var absSpeed = Mathf.Abs(_rb.linearVelocity.magnitude);
        // Move the bullet forward
        if (absSpeed < minSpeed)
        {
            //Destroy(gameObject, 0.01f); // Destroy the bullet if it slows down too much
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the bullet collides with an enemy
        if (other.gameObject.CompareTag("Collidable"))
        {
            // Here you can add code to damage the enemy or trigger an effect
            Debug.Log("Bullet hit a collidable object!");
            selfDestruct();
        }
        if (other.gameObject.CompareTag("Player"))
        {
            // Here you can add code to damage the enemy or trigger an effect
            Debug.Log("Bullet hit the player!");
            selfDestruct();
        }
    }

    private void selfDestruct()
    {
        Destroy(gameObject, 0.05f); // Destroy the bullet on impact
    }


}
