using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(h, 0, v).normalized;
        rb.MovePosition(rb.position + dir * (speed * Time.deltaTime));
        Quaternion rot = Quaternion.LookRotation(dir);
        Quaternion rotation = Quaternion.Slerp(rb.rotation, rot, (rotationSpeed * Time.deltaTime));
        rb.MoveRotation(rotation);
    }
}
