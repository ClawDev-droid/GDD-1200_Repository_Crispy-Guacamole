using UnityEngine;

public class Signature : MonoBehaviour
{
public Transform LockTo; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (LockTo != null)
        {
            transform.position = LockTo.position;
            
        }
        else
        {
            Destroy(this.gameObject);
        }
        
    }
}
