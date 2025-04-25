using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float saruSpeed = 5;
    public float saruJump = 8;
    public float saruSprint = 1;

    

    private Rigidbody2D _rigidBody;
    private GroundSensor _groundSensor;
    private Animator _animator;

    private float inputHorizontal;

    public bool doubleJump = true;


    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _groundSensor = GetComponentInChildren<GroundSensor>();
    }
    
    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");

        Movement();
        
        Sprint();

        Jump();

        DoubleJump();

        //Dash();
        
    }

    void FixedUpdate()
    {        
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
        if(Input.GetButtonDown("Dash"))
        {
            _rigidBody.AddForce(transform.right * saruJump, ForceMode2D.Impulse);
        }
    }
}