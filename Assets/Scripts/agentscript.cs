using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class agentscript : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] Transform targetTransform;
    [SerializeField] Transform Spawn;
    [SerializeField] Transform previousDestination;
    [SerializeField] Transform[] destinations;
    [SerializeField] float arrivingDistance;
    int counter;
    bool Chase = false;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Chase == true)
        {
            agent.destination = targetTransform.position;
        }
        else
        {
            if(agent.remainingDistance < arrivingDistance && !agent.pathPending)
            {
                counter++;
                if(counter >= destinations.Length)
                {
                    counter = 0;
                }
                agent.destination = destinations[counter].position;
            }
            
        }
     
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Chase = true;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Chase = false;
        }
    }
}
