using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MovementEnemyHandeler : MonoBehaviour
{
    public NavMeshAgent nmagent;
    [SerializeField] Transform [] wayPoints;
    [SerializeField]public GameObject player;
    [SerializeField] int followRange, notFollowRange;
    GameObject currentFollowTarget;
    int wayPointIndex;
    //[SerializeField]bool isFollowing = false;
    Vector3 patrolTarget;
    void Start()
    {    
        nmagent = GetComponent<NavMeshAgent>();
        UpdateDestination();
        InvokeRepeating("CheckDistanceToFollow", 0, 0.5f);

    }
    void Update()
    {
        MoveEnemy();     
    }
    void MoveEnemy() {

        if (currentFollowTarget != null) 
        { 
            nmagent.destination = currentFollowTarget.transform.position;
        }
        else 
        {
            PatrolEnemy();
        }

    }
    void CheckDistanceToFollow() 
    { 
        float dist = Vector3.Distance(transform.position, player.transform.position);

        if (dist < followRange)
        { 
            //isFollowing = true;
            currentFollowTarget = player;            
        }
        else if (dist > notFollowRange) 
        { 
            //isFollowing = false;
            currentFollowTarget = null;
        }

    }

    void PatrolEnemy() {

        UpdateDestination();

        if (Vector3.Distance(transform.position, patrolTarget) <= 10f) {

                IterateWPIndex();              
        } 

    }
    void UpdateDestination()
    { 
        patrolTarget = wayPoints[wayPointIndex].position;
        nmagent.SetDestination(patrolTarget);

    }
    void IterateWPIndex() 
    { 
        wayPointIndex++;

        if (wayPointIndex == wayPoints.Length) {

            wayPointIndex = 0;

        }

    }
}
