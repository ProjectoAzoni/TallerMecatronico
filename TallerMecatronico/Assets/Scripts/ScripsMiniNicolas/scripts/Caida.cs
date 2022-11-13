using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caida : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Enemy Enemy = other.GetComponent<Enemy>();
        CharacterController Player = other.GetComponent<CharacterController>();
        if (Enemy != null)
        {
            Enemy.Hit();
        }
        if (Player != null)
        {
            Player.Hitfull();         
        }
    }
}
