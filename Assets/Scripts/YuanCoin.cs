using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YuanCoin : MonoBehaviour
{

private CircleCollider2D _circleCollider;
private Rigidbody2D _rigidBody;


private float _velocityCoin = 7;
private float _timerCoin = 0.25f;
private float _coinRetarded = 0.1f;

void Awake()
{
    _circleCollider = GetComponent<CircleCollider2D>();
    _rigidBody = GetComponent<Rigidbody2D>();
}

void OnTriggerEnter2D(Collider2D collider)
{
    if(collider.gameObject.CompareTag("Player"))
    {
        StartCoroutine(Coin());
    }
}

IEnumerator Coin()
{
    yield return new WaitForSeconds(_coinRetarded);

    _rigidBody.AddForce(Vector2.up * _velocityCoin, ForceMode2D.Impulse);
    yield return new WaitForSeconds(_timerCoin);

    Destroy(gameObject);

}

}
