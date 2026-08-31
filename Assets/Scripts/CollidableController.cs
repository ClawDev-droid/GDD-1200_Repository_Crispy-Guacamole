using UnityEngine;

public class CollidableController : MonoBehaviour
{
    public float Health = 100f;
    public int score = 0;
    public ScoreTracker _ScoreTracker;
    public GameObject _GameManager;
    public float impactDamageSelfModifier = 1f;
    public float impactDamageSelfModifier_Player = 1f;
    private Vector2 _screenBounds;
    public bool canWarp = true;
    private Rigidbody2D _rb;
    public float dragDecay = 0.05f;
    public float baseDrag = 0.00f;
    public GameObject DeathFX;
    //public int score = 1;
    private Vector2 _initialPosition = new Vector2(-5, 2);//new Vector2(Random.Range(-_screenBounds.x, _screenBounds.x), Random.Range(-_screenBounds.y, _screenBounds.y));
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        _screenBounds = GetScreenBounds(Camera.main);
        _rb = GetComponent<Rigidbody2D>();
        var position = transform.position;
        _GameManager = GameObject.Find("GameManager");
        _ScoreTracker = _GameManager.GetComponent<ScoreTracker>();
        
    }
    private void start()
    {
        
        
        
    }
    private void Update()
    {

        ScreenWarp();
        DecayDrag();
        if (Health <= 0)
        {
            _ScoreTracker.Score += score;
            Instantiate(DeathFX, transform.position, DeathFX.transform.rotation);
            Destroy(this.gameObject);
        }
        
    }
    private void ScreenWarp()
    {
        if (canWarp = true)
        {
        var position = transform.position;
        if (position.x > _screenBounds.x)
        {
            position.x = -_screenBounds.x;
        }
        else if (position.x < -_screenBounds.x)
        {
            position.x = _screenBounds.x;
        }

        if (position.y > _screenBounds.y)
        {
            position.y = -_screenBounds.y;
        }
        else if (position.y < -_screenBounds.y)
        {
            position.y = _screenBounds.y;
        }

        transform.position = position;
        }
    }

    private Vector2 GetScreenBounds(Camera Cam)
    {
        var screenTopRight = Cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        return new Vector2(screenTopRight.x, screenTopRight.y);
    }

    private void DecayDrag()
    {
        _rb.linearDamping = baseDrag + dragDecay * _rb.linearVelocity.magnitude;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Collidable"))
        {
            Health -= (impactDamageSelfModifier * (_rb.linearVelocity.magnitude + collision.gameObject.GetComponent<Rigidbody2D>().linearVelocity.magnitude)); // reduce health on collision, scaled by velocity
            //Debug.Log("Asteroid Health: " + Health);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Health -= (impactDamageSelfModifier_Player * collision.gameObject.GetComponent<Rigidbody2D>().linearVelocity.magnitude); // reduce health on collision with Player, scaled by velocity
            //Debug.Log("Asteroid Health: " + Health);
        }
    }
}
