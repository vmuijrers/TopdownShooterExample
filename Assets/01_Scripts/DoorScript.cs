using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] private GameObject doorArt;
    [SerializeField] private float closedYPosition = 2.5f;
    [SerializeField] private float openYPosition = -2.65f;
    [SerializeField] private float duration = 2f;
    [SerializeField] private AnimationCurve animationCurve;
    private Coroutine coroutine;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void MoveDoor(bool open)
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        coroutine = StartCoroutine(OpenDoorRoutine(open ? openYPosition : closedYPosition, duration));
    }
    
    private IEnumerator OpenDoorRoutine(float yTarget, float duration)
    {
        float t = 0;
        float startY = doorArt.transform.localPosition.y;
        while (t < 1f)
        {
            t += Time.deltaTime * 1f / duration;
            yield return null; //Wait one frame
            doorArt.transform.localPosition = new Vector3(0, Mathf.Lerp(startY, yTarget, animationCurve.Evaluate(t)), 0);
        }
    }

}
