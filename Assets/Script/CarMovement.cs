using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float speed = 10f;
    public float rotationSpeed = 100f;
    public float forceUp = 500f;
    public Rigidbody rb;

    private void Start()
    {
        rb =  GetComponent<Rigidbody>();
    }
    
    private void Update()
    {
        //float moveInput = Input.GetAxis("Vertical");
        //float rotateInput = Input.GetAxis("Horizontal");

        //Vector3 moveDirection = transform.forward * moveInput;
        //Vector3 rotation = new Vector3(0, rotateInput * rotationSpeed * Time.deltaTime, 0);

        //transform.Translate(moveDirection * speed * Time.deltaTime);
        //transform.Rotate(rotation);
      
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W)) 
        {
            rb.AddForce(0, 0, forceUp * Time.deltaTime);
        }
    }
}
