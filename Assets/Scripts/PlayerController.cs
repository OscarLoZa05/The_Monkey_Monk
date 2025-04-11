using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float saruSpeed = 5;
    public float saruJump = 8;
    public float saruSprint = 1;

    private Rigidbody2D _rigidBody;

    private float inputHorizontal;


    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");

        if(Input.GetButtonDown("Sprint"))
        {
            saruSprint = 2;
        }
        else if(!Input.GetButtonDown("Sprint"))
        {
            saruSprint = 1;
        }
    }

    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        _rigidBody.velocity = new Vector2(inputHorizontal * saruSpeed * saruSprint, _rigidBody.velocity.y);
    }
}
