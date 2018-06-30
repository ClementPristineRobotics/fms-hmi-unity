using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RobotControl : MonoBehaviour {

    public Camera cam;
    public NavMeshAgent agent;
    public Transform destA;
    public Transform destB;
    public Transform flag;

    bool destSent = false;

	// Use this for initialization
	void Start () {
    }

    void Update()
    {
        // Check if we've reached the destination
        if (!agent.pathPending && !destSent)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    destSent = true;
                    Invoke("goToRandomDest", 2);//this will happen after 2 seconds
                }
            }
        }
    }

    public void goToRandomDest()
    {
        agent.speed = 0.1f;
        agent.angularSpeed = 600;
        agent.SetDestination(new Vector3(Random.Range(-10f, 10f), Random.Range(-7f, 7f), 0f));
        destSent = false;
        Debug.Log("Random Dest = " + agent.destination);
        flag.position = agent.destination;

        Invoke("goToFullSpeed", 2);//this will happen after 2 seconds
    }

    public void goToFullSpeed()
    {
        agent.angularSpeed = 100;
        agent.speed = 1;
    }

    public void goToDestA()
    {
        CancelInvoke("goToRandomDest");
        agent.speed = 0.1f;
        agent.angularSpeed = 600;
        agent.SetDestination(destA.position);
        destSent = false;
        Debug.Log("Target DestA = " + agent.destination);
        flag.position = agent.destination;

        Invoke("goToFullSpeed", 2);//this will happen after 2 seconds
    }

    public void goToDestB()
    {
        CancelInvoke("goToRandomDest");
        agent.speed = 0.1f;
        agent.angularSpeed = 600;
        agent.SetDestination(destB.position);
        destSent = false;
        Debug.Log("Target DestB = " + agent.destination);
        flag.position = agent.destination;

        Invoke("goToFullSpeed", 2);//this will happen after 2 seconds
    }

}
