using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerExample : MonoBehaviour
{
    public UnityEvent OnTriggerEvent;
    public Transform target;

    // Start is called before the first frame update
    protected void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(MoveToPositionAsync(transform.position, target.position, 3f));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (OnTriggerEvent != null)
        {
            OnTriggerEvent.Invoke();
        }

        //OnTriggerEvent?.Invoke();
    }

    private IEnumerator MoveToPositionAsync(Vector3 startPosition, Vector3 targetPosition, float duration)
    {
        float t = 0;
        while(t < 1f)
        {
            t += Time.deltaTime * 1f / duration;
            yield return null;

            //t = 0 - 1
            //A-------x--------B
            transform.position = Vector3.Lerp(startPosition, targetPosition, t);
        }
        transform.position = targetPosition;
    }

}
