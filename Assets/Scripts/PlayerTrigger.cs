using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public bool hasWon = false;


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
            {
                Debug.Log("Player found something!");
                if (collision.gameObject.CompareTag("DangerZone"))
                {
                    Debug.Log("Player rode into the danger zone!");
                    // Here I can add code to reduce player health or trigger an effect... I probably won't, though
                }
                if (collision.gameObject.CompareTag("WinCon"))
                {
                    Debug.Log("Player Won!");
                    hasWon = true;
                    // Win! or something
                }
            }
            
        }
        
    }
}
