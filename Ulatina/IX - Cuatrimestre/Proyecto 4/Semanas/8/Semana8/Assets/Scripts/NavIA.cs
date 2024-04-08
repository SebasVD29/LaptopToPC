using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavIA : MonoBehaviour
{
    public Transform objetivo;
    NavMeshAgent agent;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = objetivo.position;
        agent.speed = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = objetivo.position;
    }
}
