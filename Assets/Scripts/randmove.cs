using UnityEngine;

public class randmove : MonoBehaviour
{

    private Rigidbody2D _rb;
    public float startSpeedMin = 1;
    public float startSpeedMax = 10;
    private float startSpeed = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startSpeed = Random.Range(startSpeedMin, startSpeedMax);
        _rb = GetComponent<Rigidbody2D>();
        transform.eulerAngles = new Vector3(0, 0, Random.Range(0, 360));
        _rb.AddForce(transform.up * startSpeed, ForceMode2D.Impulse);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
