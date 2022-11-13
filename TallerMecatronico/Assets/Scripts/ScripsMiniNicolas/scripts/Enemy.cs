using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy: MonoBehaviour
{
    public Transform Player;
    public GameObject balaprefab;
    public int Health = 3;
    private Animator animator;

    private float LastShoot; 

    void Update()
    {
        if (Player == null) return;

        Vector3 direction = Player.position - transform.position;
        if (direction.x >= 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        else transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

        float distance = Mathf.Abs(Player.position.x - transform.position.x);

        if (distance < 10.0f && Time.time > LastShoot + 0.5f)
        {
            Shoot();
            LastShoot = Time.time;
        }
    }

    private void Shoot()
    {
        Vector3 direction = new Vector3(transform.localScale.x, 0.0f, 0.0f);
        GameObject Bala = Instantiate(balaprefab, transform.position + direction * 1.0f, Quaternion.identity);
        Bala.GetComponent<bala>().SetDirection(direction);
    }

    public void Hit()
    {
        //animator.SetBool("murio", false);
        Health -= 1;
    if (Health == 0)
        {
            //animator.SetBool("murio", true);
            Destroy(gameObject);
        }
    }
}