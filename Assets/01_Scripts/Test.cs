using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Test : MonoBehaviour
{
    public List<Ability> abilities = new List<Ability>();

    private FloatValue Health;
    // Start is called before the first frame update
    void Start()
    {
        Health.OnValueChanged += UpdateHealthUI;
    }

    public void TakeDamage(DamageData data)
    {
        foreach(var ability in abilities)
        {
            ability.Apply(data);
        }
        Health.Value -= data.damage;
    }


    public void AddAbility(Ability ability)
    {
        abilities.Add(ability);
        abilities = abilities.OrderBy(x => x.priority).ToList();
    }

    public void UpdateHealthUI(float old, float newValue)
    {
        //Update UI
    }
}

public abstract class Ability : ScriptableObject
{
    public int priority;
    public abstract void Apply(DamageData data);
}

public class ArmorAbility : Ability
{
    [SerializeField] private int armorAmount;
    public override void Apply(DamageData data)
    {
        data.damage -= armorAmount;
    }
}

public class DamageData
{
    public int damage;
}

public class FloatValue
{
    public System.Action<float, float> OnValueChanged;
    private float value;
    public float Value
    {
        get => value;
        set
        {
            if(this.value != value)
            {
                OnValueChanged?.Invoke(this.value, value);
            }
            this.value = value;
        }
    }
}

public class TimerManager : MonoBehaviour
{
    public List<Timer> timers = new List<Timer>();

    public void StartTimer(string name, float duration, System.Action OnFinished)
    {
        timers.Add(new Timer(name, duration, OnFinished));
    }

    public void FixedUpdate()
    {
        foreach(var timer in timers)
        {
            timer.Update(Time.deltaTime);
        }
    }

}

public class Timer
{
    public string name;
    public System.Action OnTimerFinished;
    public float maxDuration;
    private float duration;

    public Timer(string name, float maxDuration, System.Action OnFinished)
    {
        this.name = name;
        duration = maxDuration;
        this.OnTimerFinished = OnFinished;
    }

    public void Update(float deltaTime)
    {
        if(duration < 0) { return; }
        duration -= deltaTime;
        if(duration < 0)
        {
            OnTimerFinished?.Invoke();
        }
    }

    public void Reset()
    {
        duration = maxDuration;
    }
}