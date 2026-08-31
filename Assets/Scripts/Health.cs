using UnityEngine;

public class Health : MonoBehaviour
{
    public float _currentHealth;

    public float MaxHealth = 100f;
    public GameObject self;
    private Rigidbody2D _rb;
    //public float Health = 100f;
    public float impactDamageSelfModifier = 1f; // Adjust this value to control how much damage is taken based on velocity

  private void Start()
    {
        _currentHealth = MaxHealth;
        _rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(float amount)
    {
        _currentHealth -= amount;
        if (_currentHealth <= 0)
        {
            die();
        }
    }

        private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Collidable"))
        {
            _currentHealth -= (impactDamageSelfModifier * ((_rb.linearVelocity.magnitude + collision.gameObject.GetComponent<Rigidbody2D>().linearVelocity.magnitude))); // reduce health on collision, scaled by velocity
            Debug.Log("Player Health: " + _currentHealth);
            /* * (collision.gameObject.GetComponent<Rigidbody2D>().mass)*/
        }
    }

    // getters and setters
    public float GetCurrentHealth()
    {
        return _currentHealth;
    }

    private void die()
    {
        Destroy(self);
    }
}
