using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class MassDriverBullet : MonoBehaviour
{
    public float speed = 100f; // Speed of the bullet
    public float speedVariance = 0;
    public float lifetime = 5f; // Time before the bullet is destroyed
    public float armtime = 0f;
    public bool armed = true;
    public Rigidbody2D _rb;
    private CollidableController CollCont;
    public float minSpeed = 10f; // Minimum speed before the bullet disapears
    public bool canCollideWithPlayers = true;
    public bool canCollideWithCollidables = true;
    //public bool canCollideWithSignature = false;
    public bool hasCluster = false;
    public float clusterAmount = 4f;
    public float clusterSpawnDistanceFromCenter = 1f;
    public GameObject[] ClustersArray;
    private Transform SelfTransform;
    private Vector3 StockVector = new Vector3(0, 0, 1); 
    private bool dead = false;

 

    private void Start()
    {
        // Destroy the bullet after its lifetime expires
        //Destroy(gameObject, lifetime);
        //b.AddForce(Vector3.up * speed * Time.deltaTime, ForceMode2D.Impulse);
        SelfTransform = GetComponent<Transform>();
        CollCont = GetComponent<CollidableController>();
        _rb.AddForce(transform.up * (speed * Random.Range(1-speedVariance, 1+ speedVariance)), ForceMode2D.Impulse);
        //Debug.Log(gameObject.name + " spawned");
        StartCoroutine(Destruction(lifetime));
        if (!armed)
        {
            StartCoroutine(Arming(armtime));
        }
        
    }

    private void awake()
    {
        // Set the bullet's velocity to move forward
        
        
        //Destroy(gameObject, lifetime);
        
       
    }

    private void Update()
    {
        if (_rb == null)
        {
            _rb = GetComponent<Rigidbody2D>();
        }
        var absSpeed = Mathf.Abs(_rb.linearVelocity.magnitude);
        // Move the bullet forward
        if (absSpeed < minSpeed)
        {
            //Destroy(gameObject, 0.01f); // Destroy the bullet if it slows down too much
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the bullet collides with an enemy
        if (other.gameObject.CompareTag("Collidable") && canCollideWithCollidables && !other.gameObject.CompareTag("Signature"))
        {
            // Here you can add code to damage the enemy or trigger an effect
            Debug.Log("Bullet hit a collidable object!");
            selfDestruct();
            
            //Debug.Log("C");
        }
        if (other.gameObject.CompareTag("Player") && canCollideWithPlayers && !other.gameObject.CompareTag("PlayerSignature"))
        {
            // Here you can add code to damage the enemy or trigger an effect
            Debug.Log("Bullet hit the player!");
            selfDestruct();
            
            //Debug.Log("p");
        }
        if (other.gameObject.CompareTag("Signature") && CollCont.signatureCollider == true)
        {
            if (armed)
            {
                Debug.Log("Boom");
                selfDestruct();
                CollCont.Health = 0;
            }
            
            
        }
        if (other.gameObject.CompareTag("PlayerSignature") && CollCont.signatureCollider == true && CollCont.playerSignatureProjectile == false)
        {
            if (armed)
            {
                Debug.Log("Boom");
                selfDestruct();
                CollCont.Health = 0;
            }
            
        }

    }

    private void selfDestruct()
    {
        if(dead == false)
        {
        foreach (GameObject _proj in ClustersArray)
        {
            clusterSpawn(_proj);
        }
        //Debug.Log(gameObject.name + " destroyed");
        Destroy(gameObject, 0.05f); // Destroy the bullet on impact
        CollCont.DeathEffect();
        dead = true;
        
        }
    }

    private IEnumerator Destruction(float time)
    {

        yield return new WaitForSeconds(time);
        selfDestruct();
        
    }
    private IEnumerator Arming(float time)
    {

        yield return new WaitForSeconds(time);
        armed = true;
        
    }

    private void clusterSpawn(GameObject ClusterProj)
    {
        if( hasCluster == true)
        {
            for (float i = clusterAmount; i > 0; i--)
            {
                var _mult =  i/clusterAmount;
                var _Direction = new Vector3(0, 0, (360 * (_mult)));
                var _Relpos = new Vector3((Mathf.Sin(2f * Mathf.PI * (_mult))) * clusterSpawnDistanceFromCenter, (Mathf.Cos(2f * Mathf.PI * (_mult))) * clusterSpawnDistanceFromCenter, 0);
                var _Transform = SelfTransform.position + _Relpos;
                //Debug.Log(i + ", " + _mult + ", " + _Direction + ", " + _Relpos + ", " + _Transform);
                //Debug.Log(Mathf.Sin(2f * Mathf.PI * (_mult)));
                Instantiate(ClusterProj, _Transform , Quaternion.LookRotation(StockVector, _Relpos * 2));
        
            }
        }
    }

    private void OnDestroy()
    {
        
    }

}
