using UnityEngine;
using UnityEngine.AI;

public class Guard : MonoBehaviour
{
    public Animator animator;
    public GameObject Target;
    public float moveSpeed = 3f;
    public float sightRadius = 10f;
    private NavMeshAgent agent;
    private StateMachine stateMachine;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    private void Start()
    {
        stateMachine = new StateMachine(this, GetComponents<State>());
        stateMachine.SwitchState(typeof(PatrolState));
    }

    public void Update()
    {
        CheckPlayerInRange();
        stateMachine?.OnUpdate();
    }

    private void CheckPlayerInRange()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, sightRadius);
        foreach (Collider c in cols)
        {
            if (c.transform != transform)
            {
                if (c.gameObject.tag == "Player")
                {
                    Target = c.gameObject;
                    stateMachine.SwitchState(typeof(AttackState));
                    return;
                }
            }
        }
    }
    public void MoveToPosition(Vector3 targetPosition)
    {
        agent.SetDestination(targetPosition);
    }

    public void OnDied()
    {
        //animator.SetTrigger("IsDead");
        //animator.SetFloat("Kipje", 3f);
        stateMachine.SwitchState(typeof(DeadState));
    }
}
