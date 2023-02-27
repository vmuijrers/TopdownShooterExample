using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private Camera cam;
    [SerializeField] private Rigidbody rb;

    private float verticalAxis = 0;
    private float horizontalAxis = 0;

    private float verticalMouseAxis = 0;
    private float horizontalMouseAxis = 0;

    private float verticalAngle = 0;
    private float horizontalAngle = 0;

    [SerializeField] private float MouseSensX = 20;
    [SerializeField] private float MouseSensY = 20;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    private void Update()
    {
        verticalAxis = Input.GetAxis("Vertical");
        horizontalAxis = Input.GetAxis("Horizontal");

        verticalMouseAxis = Input.GetAxis("Mouse Y");
        horizontalMouseAxis = Input.GetAxis("Mouse X");

        verticalAngle += verticalMouseAxis * Time.deltaTime * MouseSensY;
        verticalAngle = Mathf.Clamp(verticalAngle, -89f, 89f);
        horizontalAngle += horizontalMouseAxis * Time.deltaTime * MouseSensX;

    }

    private void FixedUpdate()
    {
        Vector3 moveDir = (horizontalAxis * transform.right + verticalAxis * transform.forward).normalized;
        rb.MovePosition(rb.position + moveDir * moveSpeed * Time.deltaTime);

        transform.rotation = Quaternion.Euler(0, horizontalAngle, 0);
        cam.transform.localRotation = Quaternion.Euler(-verticalAngle, 0, 0);
    }
}
