using UnityEngine;
using System.Collections;

public class EnemyLookAtPlayer : MonoBehaviour
{
    private GameObject Player;
    private Transform PlayerTransform; // Reference to the player's transform
    public Transform firePoint;
    public ParticleSystem[] ThrusterEmitters;
    private Rigidbody2D _rb;
    public GameObject projectile;
    public int fireRate = 10;
    public bool shoots = true;
    public bool moves = true;
    public int detectionRange = 100;
    public int optimalRange = 100;
    private bool playerFound = false;
    private bool IsShooting = false;
    private bool IsMoving = false;
    private Coroutine _fireRoutine;
    public float _thrusterSpeed = 0.1f;
    public int thrustIntensity = 1;
    public float _turnSpeed = 0.1f;
    // Update is called once per frame
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        Player = GameObject.FindWithTag("Player");
        PlayerTransform = Player.GetComponent<Transform>();
    }
    void Update()
    {
        startFireLoop();
        stopFireLoop();
        if (PlayerTransform != null)
        {  
            // get direction of player
            Vector3 dir = transform.position - PlayerTransform.position;
            // get angle of player and convert to degrees        
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            // set rotation of enemy to look at player
            transform.localEulerAngles = new Vector3(0, 0, angle + 90); // Subtract 90 degrees to align with the sprite's forward direction
            // transform.rotation = Quaternion.LookRotation(dir); 
            if (dir.magnitude < detectionRange)
            {
                playerFound = true;
                Debug.Log(gameObject.name + ": I see you");

                
            }
            else
            {
                playerFound = false;
            }
            if (playerFound && shoots)
            {
                IsShooting = true;
            }
            else
            {
                IsShooting = false;
            }
            if (playerFound && moves && dir.magnitude > optimalRange)
            {
                _rb.AddForce(transform.up * _thrusterSpeed, ForceMode2D.Impulse);
                IsMoving = true;
            }
            else
            {
                IsMoving = false;
            }
            if (IsMoving)
            {
                foreach (ParticleSystem Thruster in ThrusterEmitters)
                {
                    Thruster.Emit(thrustIntensity);
                    Debug.Log("Thrusting");
                }
            }
        }
        else
        {
            Debug.LogWarning(gameObject.name + " is sad :(");
        }
    }
    private void startFireLoop()
    {
        if (IsShooting && _fireRoutine == null)
        {
            _fireRoutine = StartCoroutine(ShootLoop());
        }
    }
    private void stopFireLoop()
    {
        if (!IsShooting && _fireRoutine != null)
        {
            StopCoroutine(_fireRoutine);
            _fireRoutine = null;
        }
        
    }
    private IEnumerator ShootLoop()
    {
        while (true)
        {
            
            Instantiate(projectile, firePoint.transform.position, firePoint.transform.rotation);
            yield return new WaitForSeconds(fireRate);
        } 
        
    }
}
