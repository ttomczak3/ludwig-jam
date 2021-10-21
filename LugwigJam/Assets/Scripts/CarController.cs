using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarController : MonoBehaviour  {

    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";

    private float horizontalInput;
    private float verticalInput;
    private float currentSteerAngle;
    private float currentBreakForce;
    private bool isBreaking;
    private Rigidbody rb;

    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteerAngle;
    [SerializeField] private float centerOfMass;

    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider backLeftWheelCollider;
    [SerializeField] private WheelCollider backRightWheelCollider;

    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform frontRightWheelTransform;
    [SerializeField] private Transform backLeftWheelTransform;
    [SerializeField] private Transform backRightWheelTransform;



    private void FixedUpdate() {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0, centerOfMass, 0);
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }

    private void GetInput() {
        horizontalInput = Input.GetAxis(Horizontal);
        verticalInput = Input.GetAxis(Vertical);
        isBreaking = Input.GetKey(KeyCode.Space);
    }

    private void HandleMotor () {
        frontLeftWheelCollider.motorTorque = 1 * motorForce;
        frontRightWheelCollider.motorTorque = 1 * motorForce;
        backLeftWheelCollider.motorTorque = 1 * motorForce;
        backRightWheelCollider.motorTorque = 1 * motorForce;
        currentBreakForce = isBreaking ? breakForce : 0f;
        if (isBreaking == true) {
            WheelFrictionCurve LsFriction = backLeftWheelCollider.sidewaysFriction;
            LsFriction.stiffness = 10f;
            backLeftWheelCollider.sidewaysFriction = LsFriction;
            WheelFrictionCurve RsFriction = backRightWheelCollider.sidewaysFriction;
            RsFriction.stiffness = 10f;
            backRightWheelCollider.sidewaysFriction = RsFriction;
        }
        else {
            WheelFrictionCurve LsFriction = backLeftWheelCollider.sidewaysFriction;
            LsFriction.stiffness = 12f;
            backLeftWheelCollider.sidewaysFriction = LsFriction;
            WheelFrictionCurve RsFriction = backRightWheelCollider.sidewaysFriction;
            RsFriction.stiffness = 12f;
            backRightWheelCollider.sidewaysFriction = RsFriction;
        }
        ApplyBreaking();
    }

    private void ApplyBreaking() {
        backLeftWheelCollider.brakeTorque = currentBreakForce;
        backRightWheelCollider.brakeTorque = currentBreakForce;
    }

    private void HandleSteering() {
        currentSteerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
        if (isBreaking == true || verticalInput != 0 || horizontalInput != 0) {
            motorForce = 500f;
        }
        else {
            motorForce = 1000f;
        }
    }

    private void UpdateWheels() {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateSingleWheel(backRightWheelCollider, backRightWheelTransform);
        UpdateSingleWheel(backLeftWheelCollider, backLeftWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform) {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        //wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }
}
