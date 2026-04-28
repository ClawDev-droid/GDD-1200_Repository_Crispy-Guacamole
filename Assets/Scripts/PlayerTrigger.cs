using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            Debug.Log("Player found something!");
            if (collision.gameObject.CompareTag("DangerZone"))
            {
                Debug.Log("Player rode into the danger zone!");
                // Here you can add code to reduce player health or trigger an effect
            }
        }
    }
}
