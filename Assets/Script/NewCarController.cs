using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCarController : MonoBehaviour
{
    private float horizontalInput, vericalInput;
    private float currentSteeerAngle, currentbreakForce;
    private bool isBreaking;
  

    [SerializeField] private float motorForce, BreakForce, maxSteerAngle;

    [SerializeField] private Transform frontLeftWheelTransform, frontRightWheelTransform;
    [SerializeField] private Transform rearLeftWheelTransform, rearRightWheelTransform;
    [SerializeField] private WheelCollider frontRightWheelCollider, frontLeftWheelCollider, rearLeftWheelCollider, rearRightWheelCollider;

    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }
    private void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        vericalInput = Input.GetAxis("Vertical");
        isBreaking = Input.GetKey(KeyCode.Space);
    }
    private void HandleMotor()
    {
        rearLeftWheelCollider.motorTorque = vericalInput * motorForce;
        rearRightWheelCollider.motorTorque = vericalInput * motorForce;
        currentbreakForce = isBreaking ? BreakForce : 0f;
        ApplyBreaking();
    }
    private void ApplyBreaking()
    {
        frontRightWheelCollider.brakeTorque = currentbreakForce;
        frontLeftWheelCollider.brakeTorque = currentbreakForce;
        rearLeftWheelCollider.brakeTorque = currentbreakForce;
        rearRightWheelCollider.brakeTorque = currentbreakForce;

    }
    private void HandleSteering()
    {
        currentSteeerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentSteeerAngle;
        frontRightWheelCollider.steerAngle = currentSteeerAngle;
    }
    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontRightWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
    }
    private void UpdateSingleWheel(WheelCollider wheelCollider,Transform WheelTranform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        WheelTranform.rotation = rot;
        WheelTranform.position = pos;
    }


}
