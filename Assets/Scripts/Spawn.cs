using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    public PlayerController _playerController;

    public Transform _dragonSpawn;
    public GameObject _dragonPrefab;



    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _playerController = FindObjectOfType<PlayerController>().GetComponent<PlayerController>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            Instantiate(_dragonPrefab, _dragonSpawn.poition)
        }
    }
}
