using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepGlobalRotation : MonoBehaviour
{
    private Vector3 keepOffSetFromParent;
    private Quaternion rotation;
    // Start is called before the first frame update
    void Start()
    {
        keepOffSetFromParent = transform.localPosition;
        rotation = transform.rotation;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = transform.parent.position + keepOffSetFromParent;
        transform.rotation = rotation;
    }
}
