using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public float rotationSpeed = 100f;

    public GameObject gun;
    public GameObject tank;

    public float XClamp;
    public float ZClamp;

    public LayerMask groundMask;

    float horizontal;
    float vertical;
    Vector3 input;
    Vector3 targetRotation;

    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        transform.position += Vector3.forward * vertical * speed * Time.deltaTime;
        transform.position += Vector3.right * horizontal * speed * Time.deltaTime;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -XClamp, XClamp), transform.position.y, Mathf.Clamp(transform.position.z, -ZClamp, ZClamp));

        input = new Vector3(horizontal, 0, vertical);
        if (input.sqrMagnitude > 1f)
        {
            input.Normalize();
        }

        if (input != Vector3.zero)
            targetRotation = Quaternion.LookRotation(input).eulerAngles;

        tank.transform.rotation = Quaternion.Slerp(tank.transform.rotation, Quaternion.Euler(targetRotation), Time.deltaTime * rotationSpeed);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray.origin, ray.direction, out hit, groundMask))
        {
            Vector3 lookAtPosition = new Vector3(hit.point.x, gun.transform.position.y, hit.point.z);
            gun.transform.LookAt(lookAtPosition);
        }
    }
}
