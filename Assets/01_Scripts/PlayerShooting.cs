using UnityEngine;
using UnityEngine.Events;

public class PlayerShooting : MonoBehaviour
{
    public float rotationSpeed = 180f;

    public GameObject bulletPrefab;
    public Transform shootPoint;
    public UnityEvent OnShootEvent;
    public void Update()
    {
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y));
        worldMousePosition.y = 0;
        //transform.rotation = Quaternion.LookRotation(worldMousePosition - transform.position);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(worldMousePosition - transform.position), rotationSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        OnShootEvent?.Invoke();
    }
}


