using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala2 : MonoBehaviour
{
    public float Speed;
    //public AudioClip Sound;

    private Rigidbody2D Rigidbody2D;
    private Vector2 Direction;

    private void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    //    Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = Direction * Speed;
    }

    public void SetDirection(Vector2 direction)
    {
        Direction = direction;
    }

    public void destruirbala()
    {
        Destroy(gameObject);
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
            Player.Hit();
        }
        destruirbala();
    }
}