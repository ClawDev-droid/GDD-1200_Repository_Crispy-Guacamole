using UnityEngine;

public class Health : MonoBehaviour
{
  private int _currentHealth;

  public int MaxHealth = 10;


  private void Start()
    {
        _currentHealth = MaxHealth;
    }

    public void TakeDamage(int amount)
    {
        _currentHealth -= amount;
        if (_currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
