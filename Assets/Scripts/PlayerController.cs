using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    [Header("Movement")]
    private float inputHorizontal;

    public float saruSpeed = 7;
    public float saruJump = 8;
    public float saruSprint = 1;
    public bool doubleJump = true;

    [Header("Dash")]
    [SerializeField] private float _dashForce = 20;
    [SerializeField] private float _dashDuration = 0.2f;
    [SerializeField] private float _dashCoolDown = 2f;
    private bool _canDash = true;
    private bool _isDashing = false;

    

    private Rigidbody2D _rigidBody;
    private GroundSensor _groundSensor;
    private Animator _animator;

    

    


    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _groundSensor = GetComponentInChildren<GroundSensor>();
    }
    
    void Update()
    {
        if(_isDashing)
        {
            return;
        } 
        inputHorizontal = Input.GetAxisRaw("Horizontal");

        Movement();
        
        Sprint();

        Jump();

        DoubleJump();

        //Condicion del Dash
        if(Input.GetButtonDown("Dash") && _canDash)
        {
            StartCoroutine(Dash());
        }

        

        
    }

    void FixedUpdate()
    {        
        if(_isDashing)
        {
            return;
        }
        _rigidBody.velocity = new Vector2(inputHorizontal * saruSpeed * saruSprint, _rigidBody.velocity.y);
    }


 
    //Lista de acciones

    void Sprint()
    {
        if(Input.GetButton("Sprint") && _groundSensor.isGrounded)
        {
            saruSprint = 1.50f;
        }
        else if(!Input.GetButtonUp("Sprint") && _groundSensor.isGrounded)
        {
            saruSprint = 1;
        }
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump") && _groundSensor.isGrounded)
        {
            _rigidBody.AddForce(Vector2.up * saruJump, ForceMode2D.Impulse);
            _animator.SetBool("IsJumping", true);
        }
    }

    void DoubleJump()
    {
        if(Input.GetButtonDown("Jump") && !_groundSensor.isGrounded && doubleJump)
        {
            _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, 0);
            _rigidBody.AddForce(Vector2.up * saruJump, ForceMode2D.Impulse);
            doubleJump = false;
        }
    }

    void Movement()
    {

        _animator.SetBool("IsJumping", !_groundSensor.isGrounded); 

        if(inputHorizontal > 0)
        {
            _rigidBody.velocity = new Vector2(inputHorizontal * saruSpeed * saruSprint, _rigidBody.velocity.y);
            _animator.SetBool("IsRunning", true);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if(inputHorizontal < 0)
        {
            _rigidBody.velocity = new Vector2(inputHorizontal * saruSpeed * saruSprint, _rigidBody.velocity.y);
            _animator.SetBool("IsRunning", true);
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            _animator.SetBool("IsRunning", false);
        }

        
        
    }


    IEnumerator Dash()
    {
        float gravity = _rigidBody.gravityScale;
        _rigidBody.gravityScale = 0;
        _rigidBody.velocity = new Vector2(_rigidBody.velocity.x ,0); 
        
        
        _isDashing = true;
        _canDash = false;
        _rigidBody.AddForce(transform.right*_dashForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(_dashDuration);
        _rigidBody.gravityScale = gravity;
        _isDashing = false;
        yield return new WaitForSeconds(_dashCoolDown);
        _canDash = true;
    }
}