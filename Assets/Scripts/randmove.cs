using UnityEngine;

public class randmove : MonoBehaviour
{

    private Rigidbody2D _rb;
    public float startSpeedMin = 1;
    public float startSpeedMax = 10;
    private float startSpeed = 1;
    public bool rotate = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startSpeed = Random.Range(startSpeedMin, startSpeedMax);
        _rb = GetComponent<Rigidbody2D>();
        var turndirect = new Vector3(0, 0, Random.Range(0, 360));
        if (rotate)
        {
            transform.eulerAngles = turndirect;
        }
        
        _rb.AddForce(turndirect * startSpeed, ForceMode2D.Impulse);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
