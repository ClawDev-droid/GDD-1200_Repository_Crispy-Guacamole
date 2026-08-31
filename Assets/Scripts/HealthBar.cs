using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{


    public GameObject target;
    public Slider SliderBar;

    private Health _health;

    private void Start()
    {
        // assign health to the Health Script
        _health = target.GetComponent<Health>();
        // set sider max to max health 
        SliderBar.maxValue = _health.MaxHealth;
    }

    private void Update()
    {
        SliderBar.value = _health.GetCurrentHealth();
    }
}
