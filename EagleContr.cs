using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EagleContr : MonoBehaviour
{
    NavMeshAgent agent;
    Vector3 target;
    public GameObject player;
    float distanceToPlayer;
    float distance = 20f;
    Transform playerTR;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerTR = player.GetComponent<Transform>();
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
    }
}
