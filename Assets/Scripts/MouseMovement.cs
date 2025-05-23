using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{

    private int _mouseDamage = 2;
    public int _mousePoints = 500;
    public int direction = 1;
    private float speed = 8;

    private GameManager _gameManager;
    private PlayerController _playerController;
    private BoxCollider2D _boxCollider2D;
    private Rigidbody2D _rigidBody;
    private SpriteRenderer _spriteRenderer;

    void Awake()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _rigidBody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _gameManager = FindObjectOfType<GameManager>();GetComponent<GameManager>();
        _playerController = FindObjectOfType<PlayerController>();GetComponent<PlayerController>();
    }

    void FixedUpdate()
    {
        _rigidBody.velocity = new Vector2(direction * speed, _rigidBody.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            _playerController.TakeDamage(_mouseDamage);
            direction *= -1;
            _spriteRenderer.flipX = true;

        }
        else if(collision.gameObject.layer == 6)
        {
            direction *= -1;
            _spriteRenderer.flipX = true;
        }
    }

}
