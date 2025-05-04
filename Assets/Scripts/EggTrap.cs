using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggTrap : MonoBehaviour
{
   
    [SerializeField] private Transform _eggPostition;
    [SerializeField] private GameObject _pollito;   
 
 
    private BoxCollider2D _boxCollider;
    
    void Awake()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 3)
        {
            Instantiate(_pollito, _eggPostition.position, _eggPostition.rotation);
            Destroy(gameObject);
        }
    }
}
