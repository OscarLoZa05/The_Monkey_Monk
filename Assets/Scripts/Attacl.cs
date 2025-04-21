using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacl : MonoBehaviour
{
    
    private Rigidbody2D _rigidBody;

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, 8);
    }
}
