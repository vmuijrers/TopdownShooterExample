using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody rigidBody;
    public float moveSpeed = 3f;
    private Vector3 moveDirection;

    //Updates the Input
    public void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        moveDirection = new Vector3(0, 0, 0);
        if (vertical != 0 || horizontal != 0)
        {
            moveDirection = new Vector3(horizontal, 0, vertical);
        }
    }

    //Updates the phyiscs
    public void FixedUpdate()
    {
        rigidBody.MovePosition(rigidBody.position + moveDirection.normalized * moveSpeed * Time.deltaTime);
    }
}
