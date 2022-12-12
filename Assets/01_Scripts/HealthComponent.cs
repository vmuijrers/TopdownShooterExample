using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthComponent : MonoBehaviour, IDamageable
{
    public UnityEvent<float> OnHealthChanged;
    public UnityEvent OnDiedEvent;
    [SerializeField] private float health = 100;
    public float Health { 
        get { return health; } 
        set 
        { 
            health = value; 
            OnHealthChanged?.Invoke(health); 
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    [ContextMenu("TakeDamage")]
    private void TakeSomeDamage()
    {
        OnTakeDamage(25);
    }

    public void OnTakeDamage(float damage)
    {
        if (Health <= 0) { return; }
        health -= damage;
        OnHealthChanged?.Invoke(health); 
        if (Health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        OnDiedEvent?.Invoke();
        //Destroy(gameObject);
    }
}
