using UnityEngine;
using UnityEngine.AI;

public class DeadState : State
{

    public override void OnEnter()
    {
        GetComponent<NavMeshAgent>().isStopped = true;
    }

    public override void OnExit()
    {
    }

    public override void OnUpdate()
    {

    }
}