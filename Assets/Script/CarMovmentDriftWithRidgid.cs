using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovmentDriftWithRidgid : MonoBehaviour
{
    // Start is called before the first frame update
    // Settings
    public float MoveSpeed ;
    public float MaxSpeed ;
    public float Drag ;
    public float SteerAngle ;
    public float Traction ;

    
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Moving
        float forwardInput = Input.GetAxis("Vertical");
        Vector3 force = transform.forward * forwardInput * MoveSpeed * Time.deltaTime;
        rb.AddForce(force);

        // Steering
        float steerInput = Input.GetAxis("Horizontal");
        Vector3 steerTorque = Vector3.up * steerInput * SteerAngle * Time.deltaTime;
        rb.AddTorque(steerTorque);

        // Drag and max speed limit
        rb.velocity *= Drag;
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, MaxSpeed);
    }
}
