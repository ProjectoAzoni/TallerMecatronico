using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCollisionHandeler : MonoBehaviour
{
    [SerializeField] HealtControler myHealth;
    [SerializeField] PlayerCollisionHandeler pch;
    [SerializeField] MovementEnemyHandeler meh;
    NavMeshAgent agent;
    GameObject player;
    float dist;

    void Start()
    {
        //Set my local agent and player to the external ones 
        agent = meh.nmagent;
        player = meh.player;
        //Calls the funcition CheckDistance every 1s from the time = 0        
        InvokeRepeating("CheckDistance",0,1);
    }

    // Update is not used :v
    void Update()
    {

    }
    //Checks the distance between the enemy and player and ask if enemy is stopped
    public void CheckDistance()
    {
        dist = Vector3.Distance(transform.position, player.transform.position);
        IsStopped(dist);     
    }
    //check if enemy isn't moving and do something if true
    public void IsStopped(float dis)
    {         
        // check if enemy is moving
        if (dis <= agent.stoppingDistance && gameObject.activeInHierarchy)
        {
            // Have the player take damage acording to the type of enemy
            switch(gameObject.tag){
                case "E0": // Tutorial Enemy
                    pch.TakeDamage(5);
                    return;
                case "E1": // Straw Enemy
                    pch.TakeDamage(20);
                    return;
                case "E2": // Cloud bottle enemy
                    pch.TakeDamage(40);
                    return;
                case "E3": // box thing enemy
                    pch.TakeDamage(10);
                    return;
                case "E4":
                    pch.TakeDamage(30);
                    return;
                case "E5":
                    pch.TakeDamage(30);
                    return;
                case "E6":
                    pch.TakeDamage(35);
                    return;
                case "E7":
                    pch.TakeDamage(40);
                    return;
                case "E8":
                    pch.TakeDamage(45);
                    return;
            }

        }
    }
//Rest my health when used
    public void TakeDamage(int dmg){
        myHealth.RestHealth(dmg);
    }
    public void TakeDamageBullet(string bullet, int damage){
        if(gameObject.tag == "E0" && bullet == "B00")
        {
            TakeDamage(damage);
        } else if (gameObject.tag == "E0" && bullet == "B01")
        {
            TakeDamage(damage+5);
        } else if (gameObject.tag == "E1" && bullet == "B00")
        {
            TakeDamage(damage - 5);
        }
        else if (gameObject.tag == "E1" && bullet == "B01")
        {
            TakeDamage(damage - 5);
        }
        else if (gameObject.tag == "E1" && bullet == "B10")
        {
            TakeDamage(damage);
        }
        else if (gameObject.tag == "E1" && bullet == "B11")
        {
            TakeDamage(damage + 5);
        }

         else if (gameObject.tag == "E2" && bullet == "B00")
        {
            TakeDamage(damage);
        }
        else if (gameObject.tag == "E2" && bullet == "B01")
        {
            TakeDamage(damage - 5);
        }
        else if (gameObject.tag == "E2" && bullet == "B10")
        {
            TakeDamage(damage- 10);
        }
        else if (gameObject.tag == "E2" && bullet == "B11")
        {
            TakeDamage(damage);
        }

        else if (gameObject.tag == "E3" && bullet == "B00")
        {
            TakeDamage(damage + 5);
        }
        else if (gameObject.tag == "E3" && bullet == "B01")
        {
            TakeDamage(damage + 10);
        }
        else if (gameObject.tag == "E3" && bullet == "B10")
        {
            TakeDamage(damage - 10);
        }
        else if (gameObject.tag == "E3" && bullet == "B11")
        {
            TakeDamage(damage - 15);
        }

        else if (gameObject.tag == "E4" && bullet == "B00")
        {
            TakeDamage(5);
        }
        else if (gameObject.tag == "E4" && bullet == "B01")
        {
            TakeDamage(5);
        }
        else if (gameObject.tag == "E4" && bullet == "B10")
        {
            TakeDamage(5);
        }
        else if (gameObject.tag == "E4" && bullet == "B11")
        {
            TakeDamage(5);
        }
        
    }
//Check if i have collided with something
    void OnCollisionEnter(Collision collision)
    {
        
    }

}
