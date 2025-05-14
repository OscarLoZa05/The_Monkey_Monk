using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pollito : MonoBehaviour
{
   
    private float _chickSpeed = 5;
    private float _chickDirection;


    private Rigidbody2D _rigidBody;
    private BoxCollider2D _boxCollider;
    private GrullaTrap _grullaTrap;


    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _grullaTrap = FindObjectOfType<GrullaTrap>().GetComponent<GrullaTrap>();
    }


    void Start()
    {
        _chickDirection = _grullaTrap.plumillaDirection;
    }
   
    void FixedUpdate()
    {
       
        _rigidBody.velocity = new Vector2(_chickSpeed * _chickDirection, _rigidBody.velocity.y);


    }    
}

