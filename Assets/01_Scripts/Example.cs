using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Vector3.ProjectOnPlane - example

// Generate a random plane in xy. Show the position of a random
// vector and a connection to the plane. The example shows nothing
// in the Game view but uses Update(). The script reference example
// uses Gizmos to show the positions and axes in the Scene.

public class Example : MonoBehaviour
{
    public Transform target;
    private Vector3 projectedPosition;
    // Generate the values for all the examples.
    // Change the example every two seconds.
    void Update()
    {
        projectedPosition = Vector3.ProjectOnPlane(target.position - transform.position, transform.up);
    }

    // Show a Scene view example.
    void OnDrawGizmos()
    { 
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position + projectedPosition, 1f);
    }
}
