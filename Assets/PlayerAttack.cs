using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;


public class PlayerAttack : MonoBehaviour
{
    public string weaponType = "Mass Driver";
    private ShipInput _playerInput;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _playerInput = new ShipInput();
        _playerInput.Player.Fire.performed += OnFirePerformed;
        //_playerInput.Player.Fire.canceled += OnFireCanceled;
        _playerInput.Player.Enable();
    }
    private void OnFirePerformed(InputAction.CallbackContext context)
    {
        fireWeapon();
        
    }

    /*private void OnMoveCanceled(InputAction.CallbackContext context)
    {
        _moveInput = Vector2.zero;
    }*/

    void fireWeapon()
    {
        // Implement weapon firing logic here
        Debug.Log("Firing " + weaponType);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
