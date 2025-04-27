using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YuanCoin : MonoBehaviour
{

private CircleCollider2D _circleCollider;

void Awake()
{
    _circleCollider = GetComponent<CircleCollider2D>();
}

void OnTriggerEnter2D(Collider2D collider)
{
    if(collider.gameObject.CompareTag("Player"))
    {
        Destroy(gameObject);
    }
}

}
