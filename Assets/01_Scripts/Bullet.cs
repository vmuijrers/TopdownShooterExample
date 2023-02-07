using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    public float force = 1000;
    public int damage = 10;
    public UnityEvent<Vector3, Quaternion> OnDestroyed;
    public AudioObject audioHit;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * force);
    }

    //private void OnTriggerEnter(Collider other)
    //{
        
    //}
    //private void OnCollisionEnter(Collision other)
    //{
    //    RaycastHit hit;
    //    if(Physics.Raycast(transform.position, transform.forward,out hit, 1f))
    //    {
    //        OnDestroyed?.Invoke(hit.point, Quaternion.LookRotation(hit.normal));
    //    }
    //    Destroy(gameObject);
    //}

    private void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1f))
        {
            HealthComponent health = hit.collider.GetComponent<HealthComponent>();
            if (health != null)
            {
                health.OnTakeDamage(damage);
            }
            AudioManager.Instance.PlayObject(audioHit, transform.position);
            OnDestroyed?.Invoke(hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(gameObject);
        }
        
    }
}
