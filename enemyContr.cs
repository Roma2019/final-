using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyContr : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform[] waypoints;
    int waypointIndex;
    Vector3 target;
    public GameObject player;
    float distanceToPlayer;
    float distance = 15f;
    Transform playerTR;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerTR = player.GetComponent<Transform>();
        UpdateDestination();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * 15f, Color.green);
        Debug.DrawRay(transform.position, transform.right * 15f, Color.green);
        Debug.DrawRay(transform.position, transform.forward * -15f, Color.green);
        Debug.DrawRay(transform.position, transform.right * -15f, Color.green);
        distanceToPlayer = Vector3.Distance(player.transform.position, agent.transform.position);
        if(distanceToPlayer <= distance){
            agent.SetDestination(playerTR.position);
        }
        if(distanceToPlayer > distance){
            UpdateDestination();
            if(Vector3.Distance(transform.position, target) < 1)
                {
                    IterateWaypointIndex();
                    UpdateDestination();
                } 
        }
        
    }
    void  UpdateDestination()
        {
            target = waypoints[waypointIndex].position;
            agent.SetDestination(target);
        }
    void IterateWaypointIndex(){
        waypointIndex++;
        if(waypointIndex == waypoints.Length){
            waypointIndex = 0;
        }
    }
}
