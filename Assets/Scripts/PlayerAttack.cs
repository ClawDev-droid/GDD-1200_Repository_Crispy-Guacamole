using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;


public class PlayerAttack : MonoBehaviour
{
    public string weaponType = "Mass Driver";
    private ShipInput _playerInput;
    public GameObject firePoint;
    public GameObject projectile;
    public float fireRate = 0.5f; // Fire rate in seconds
    private bool IsShooting = false;
    private Coroutine _fireRoutine;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _playerInput = new ShipInput();
        _playerInput.Player.Fire.performed += OnFirePerformed;
        _playerInput.Player.Fire.canceled += OnFireCanceled;
        _playerInput.Player.Enable();
    }
    
    private void OnFirePerformed(InputAction.CallbackContext context)
    {
        IsShooting = true;
       /* if (IsShooting == false)
        {
            IsShooting = true;
            fireWeapon();
            startFireLoop();
        }
        else
        {
            IsShooting = false;
            stopFireLoop();
        }*/
        

    }

    private void OnFireCanceled(InputAction.CallbackContext context)
    {
        IsShooting = false;
        //stopFireLoop();
    }

    void fireWeapon()
    {
        // Implement weapon firing logic here
        Debug.Log("Firing " + weaponType);
        
    }

    private IEnumerator ShootLoop()
    {
        while (true)
        {
            
            Instantiate(projectile, firePoint.transform.position, firePoint.transform.rotation);
            yield return new WaitForSeconds(fireRate);
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

    /* private IEnumerator FireRoutine()
    {
        while (IsShooting)
        {
            fireWeapon();
            yield return new WaitForSeconds(fireRate);
        }
    }*/
    private void start()
    {
        
    }
    // Update is called once per frame
    private void Update()
    {
        startFireLoop();
        stopFireLoop();
    }
}
