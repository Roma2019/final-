using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class eagleStalker : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject player;
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
        agent.SetDestination(playerTR.position); 
    }
}