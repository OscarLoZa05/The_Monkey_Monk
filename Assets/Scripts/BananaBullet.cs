using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BananaBullet : MonoBehaviour
{
    public float speed = -300;
    

    void Start()
    {
        _rigidBody.velocity = new Vector2(_inputHorizontal * saruSpeed * saruSprint, _rigidBody.velocity.y);
    }
    
    void FixedUpdate()
    {
        transform.Rotate(0,0,speed * Time.deltaTime);
    }
}
