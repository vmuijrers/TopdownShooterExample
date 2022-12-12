using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolGuard : MonoBehaviour
{
    public enum State { Idle, Patrol, Chase }

    public State activeState;

    public Transform Player;
    public float chaseDistance = 5f;

    private float waitTime;
    public float maxWaitTime = 3f;

    public List<Transform> patrolPoints;
    private int patrolPointIndex = 0;

    public NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    { 
        //Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateState();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, chaseDistance);
    }

    public void UpdateState()
    {
        switch (activeState)
        {
            case State.Idle:
                IdleBehaviour();
                break;
            case State.Patrol:
                PatrolBehaviour();
                break;
            case State.Chase:
                ChaseBehaviour();
                break;
        }
    }

    public void IdleBehaviour()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, Player.position);
        if(distanceToPlayer <= chaseDistance)
        {
            activeState = State.Chase;
            return;
        }

        waitTime -= Time.deltaTime;
        if(waitTime <= 0)
        {
            activeState = State.Patrol;
            waitTime = maxWaitTime;
        }
    }

    public void PatrolBehaviour()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, Player.position);
        if (distanceToPlayer <= chaseDistance)
        {
            activeState = State.Chase;
            return;
        }

        Vector3 targetPosition = patrolPoints[patrolPointIndex].position;
        if(Vector3.Distance(transform.position, targetPosition) < 1f)
        {
            activeState = State.Idle;
            patrolPointIndex += 1;
            if(patrolPointIndex >= patrolPoints.Count)
            {
                patrolPointIndex = 0;
            }
        } else
        {
            //Move To targetPosition
            agent.SetDestination(targetPosition);
        }
    
    }

    public void ChaseBehaviour()
    {
        agent.SetDestination(Player.position);
    }
}
