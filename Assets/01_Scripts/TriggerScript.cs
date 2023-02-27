using UnityEngine;
using UnityEngine.Events;

public class TriggerScript : MonoBehaviour
{
    public UnityEvent OnTriggerEnteredEvent;
    public UnityEvent OnTriggerExitEvent;
    public LayerMask triggerLayerMask;

    private BoxCollider triggerCollider;

    private bool isObjectInTrigger = false; //Backing field of the property
    public bool IsObjectInTrigger //Property
    {
        get { return isObjectInTrigger; }
        set
        {
            if(!isObjectInTrigger && value)
            {
                OnTriggerEnteredEvent?.Invoke();
            }
            if (isObjectInTrigger && !value)
            {
                OnTriggerExitEvent?.Invoke();
            }
            isObjectInTrigger = value;
        }
    }

    private void Awake()
    {
        triggerCollider = GetComponent<BoxCollider>();
    }

    private void FixedUpdate()
    {
        Collider[] cols = Physics.OverlapBox(triggerCollider.center, triggerCollider.size * 0.5f, transform.rotation, triggerLayerMask);
        IsObjectInTrigger = cols.Length > 0;
    }

    //public void OnTriggerEnter(Collider other)
    //{
    //    OnTriggerEnteredEvent?.Invoke();
    //}

    //public void OnTriggerExit(Collider other)
    //{
    //    OnTriggerExitEvent?.Invoke();
    //}
}
