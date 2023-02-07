using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

//Weapon
//IAttack
//ICooldown

public abstract class Weapon : MonoBehaviour
{
    //public Attack Attack { get; private set; }
    //public Cooldown Cooldown { get; private set; }

    public UnityEvent OnClickEvent;

    private void Awake()
    {
        //Cooldown = GetComponent<Cooldown>();
        //Attack = GetComponent<Attack>();
        //Attack.Init(this);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            OnClickEvent?.Invoke();
        }
    }
}

public class Cooldown : MonoBehaviour
{
    private float time = 0;
    public bool IsDone => time <= 0;

    public UnityEvent OnCooldownDone;
    public void OnCheckCooldownDone()
    {
        if (IsDone)
        {
            OnCooldownDone?.Invoke();
        }
    }

    public void ResetTimer(float maxTime)
    {
        time = maxTime;
    }
    public void UpdateTimer(float deltaTime)
    {
        if(time > 0)
        {
            time -= deltaTime;
        }
    }
}

public abstract class Attack : MonoBehaviour
{
    public virtual void Init(Weapon weapon) { }
    public abstract void DoAttack(AttackData data);
}

public class MeleeAttack : Attack
{
    public SpecificMeleeAttackData AttackData;

    public override void Init(Weapon weapon)
    {
        weapon.Cooldown.ResetTimer(AttackData.cooldown);
    }
    public override void DoAttack(AttackData data)
    {

    }
}

public class RangedAttack : Attack
{
    public override void DoAttack(AttackData data)
    {
        throw new System.NotImplementedException();
    }
}

public class AttackData : ScriptableObject
{

}

public class SpecificMeleeAttackData : AttackData 
{
    public float cooldown;
}
