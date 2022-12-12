using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    private float strength;
    private float decay;
    private Vector3 originalPosition;
    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.localPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (strength <= 0.01f) { return; }
        transform.localPosition = originalPosition + new Vector3(Random.Range(-strength, strength), Random.Range(-strength, strength), 0);
        strength *= decay;
        if(strength <= 0.01f)
        {
            strength = 0;
            transform.localPosition = originalPosition;
        }
    }

    public void SimpleShake()
    {
        Shake(1f, 0.91f);
    }

    public void Shake(float strength, float decay)
    {
        this.strength = strength;
        this.decay = decay;
    }
}
