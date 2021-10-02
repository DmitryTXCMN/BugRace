using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CarController : MonoBehaviour
{
    public float maxMotorTorque;
    public float maxSteeringAngle;

    [SerializeField] private GameObject frontLeftWheel;
    [SerializeField] private GameObject frontRightWheel;
    [SerializeField] private GameObject rearLeftWheel;
    [SerializeField] private GameObject rearRightWheel;
    private WheelCollider _frontLeftWheelCol;
    private WheelCollider _frontRightWheelCol;
    private WheelCollider _rearLeftWheelCol;
    private WheelCollider _rearRightWheelCol;
    
      public void Start()
      {
          _frontLeftWheelCol = frontLeftWheel.GetComponent<WheelCollider>();
          _frontRightWheelCol = frontRightWheel.GetComponent<WheelCollider>();
          _rearLeftWheelCol = rearLeftWheel.GetComponent<WheelCollider>();
          _rearRightWheelCol = rearRightWheel.GetComponent<WheelCollider>();
      }

    public void FixedUpdate()
    {
        var motor = maxMotorTorque * Input.GetAxis("Vertical");
        var steering = maxSteeringAngle * Input.GetAxis("Horizontal");
        
        _frontLeftWheelCol.steerAngle = steering;
        _frontRightWheelCol.steerAngle = steering;
        _frontLeftWheelCol.motorTorque = motor;
        _frontRightWheelCol.motorTorque = motor;

        UpdateWheelPos(_frontLeftWheelCol,frontLeftWheel.transform);
        UpdateWheelPos(_frontRightWheelCol,frontRightWheel.transform);
        UpdateWheelPos(_rearLeftWheelCol,rearLeftWheel.transform);
        UpdateWheelPos(_rearRightWheelCol,rearRightWheel.transform);
    }

    private void UpdateWheelPos(WheelCollider wheelCollider, Transform transform)
    {
        Quaternion quat = transform.rotation;
        
        wheelCollider.GetWorldPose(out _,out quat);

        transform.rotation = quat;
    }
}