using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float Health = 100f;
    public float impactDamageSelfModifier = 1f; // Adjust this value to control how much damage is taken based on velocity
    private ShipInput _playerInput;
    //private Vector2 _moveInput;
    private float _moveInput;
    private float _turnInput;
    private float _moveSpeed = 5f;
    public float _thrusterSpeed = 0.1f;
    public float _retroThrusterSpeed = 0.025f;
    public float _turnSpeed = 0.0001f;
    private Vector2 _screenBounds;
    private Rigidbody2D _rb;
    public float dragDecay = 0.05f;
    public float baseDrag = 0.00f;
    public float spinDragDecay = 0.1f;
    public float spinBaseDrag = 1f;


    private void onEnable()
    {
        _playerInput.Player.Enable();
    }

    private void onDisable()
    {
        _playerInput.Player.Disable();
    }

    private void Awake()
    {
       
        _playerInput = new ShipInput();
        _playerInput.Player.Move.performed += OnMovePerformed;
        _playerInput.Player.Move.canceled += OnMoveCanceled;
        _playerInput.Player.Turn.performed += OnTurnPerformed;
        _playerInput.Player.Turn.canceled += OnTurnCanceled;
        _playerInput.Player.Enable();
        
    }

    private void Start()
    {
        _playerInput.Player.Enable();
        _screenBounds = GetScreenBounds(Camera.main);
        _rb = GetComponent<Rigidbody2D>();
        _playerInput.Player.Enable();
    }

    private void Update()
    {
        //HandleMovement();
        //ClampToScreen();
        ScreenWarp();
        DecayDrag();
        SpinDecayDrag();
        
    }

    private void FixedUpdate()
    {
        PhysicsHandleMovement();
        

        //ClampToScreen();
    }

    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<float>();
        //Debug.Log("Move input performed: " + _moveInput);
        
    }

    private void OnMoveCanceled(InputAction.CallbackContext context)
    {
        _moveInput = 0f;
        //Debug.Log("Move input canceled, setting to zero.");
    }
    private void OnTurnPerformed(InputAction.CallbackContext context)
    {
        _turnInput = context.ReadValue<float>();
        //Debug.Log("Turn input performed: " + _turnInput);
        
    }

    private void OnTurnCanceled(InputAction.CallbackContext context)
    {
        _turnInput = 0f;
        //Debug.Log("Turn input canceled, setting to zero.");
    }

    private void HandleMovement()
    {
        //Vector3 moveDirection = new Vector3(_moveInput.x, _moveInput.y, 0);
        //transform.position += moveDirection * _moveSpeed * Time.deltaTime;
    }

    private Vector2 GetScreenBounds(Camera Cam)
    {
        var screenTopRight = Cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        return new Vector2(screenTopRight.x, screenTopRight.y);
    }


    private void ClampToScreen()
    {
        var position = transform.position;
        var halfShipWidth = transform.localScale.x / 2.0f;
        var halfShipHeight = transform.localScale.y / 2.0f;
        position.x = Mathf.Clamp(position.x, min:-_screenBounds.x + halfShipWidth, max:_screenBounds.x - halfShipWidth);
        position.y = Mathf.Clamp(position.y, min:-_screenBounds.y + halfShipHeight, max:_screenBounds.y - halfShipHeight);

        transform.position = position;
    }  
    private void PhysicsHandleMovement()
    {
        if (_moveInput > 0)
        {
            _rb.AddForce(transform.up * _thrusterSpeed * _moveInput, ForceMode2D.Impulse);
        }
        else if (_moveInput < 0)
        {
            _rb.AddForce(transform.up * _retroThrusterSpeed * _moveInput, ForceMode2D.Impulse);
        }
        //_rb.AddForce(transform.up * _thrusterSpeed * _moveInput, ForceMode2D.Impulse);
        _rb.AddTorque(_turnInput * _turnSpeed, ForceMode2D.Force);
        //_rb.AddForce(_moveInput * _thrusterSpeed, ForceMode2D.Force);   
        //_rb.linearVelocity = _moveInput * _thrusterSpeed; 
    }

    private void ScreenWarp()
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


    private void DecayDrag()
    {
        _rb.linearDamping = baseDrag + dragDecay * _rb.linearVelocity.magnitude;
    }
    private void SpinDecayDrag()
    {
        _rb.angularDamping = spinBaseDrag + spinDragDecay * Mathf.Abs(_rb.angularVelocity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Collidable"))
        {
            Health -= (impactDamageSelfModifier * _rb.linearVelocity.magnitude); // reduce health on collision, scaled by velocity
            Debug.Log("Player Health: " + Health);
        }
    }

}
