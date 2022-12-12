using UnityEngine;

public class AttackState : State
{
    public float AttackDistance = 1f;
    public float AlertDistance = 5f;
    public float Damage = 10f;
    private float attackRate;
    private float maxAttackRate = 1f;
    public override void OnEnter()
    {
        attackRate = maxAttackRate;
        Controller.Controller.MoveToPosition(Controller.Controller.Target.transform.position);
    }

    public override void OnExit()
    {
    }

    public override void OnUpdate()
    {
        if(attackRate > 0f)
        {
            attackRate -= Time.deltaTime;
        }
        
        float distanceToTarget = Vector3.Distance(transform.position, Controller.Controller.Target.transform.position);
        //Transition
        if (distanceToTarget > AlertDistance)
        {
            Controller.SwitchState(typeof(IdleState)); 
        }else if(distanceToTarget < AttackDistance)
        {
            if(attackRate <= 0f)
            {
                IDamageable dam = Controller.Controller.Target.GetComponent<IDamageable>();
                if (dam != null)
                {
                    dam.OnTakeDamage(Damage);
                }
                attackRate = maxAttackRate;
            }
        }

        //Move
        Controller.Controller.MoveToPosition(Controller.Controller.Target.transform.position);
    }
}