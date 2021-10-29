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
    private int currentGear = 1;
    public float currentRPM;


    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteerAngle;
    [SerializeField] private float centerOfMass;

    [SerializeField] private GameObject speedometer;
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
        
        switch (speedometer.GetComponent<Speedometer>().speed) {
            case float n when n <= 69: 
                motorForce = 1454;
                currentRPM = (speedometer.GetComponent<Speedometer>().speed / 69) * 7500;
                //gameObject.GetComponent<Rigidbody>().drag = 0f;
                break;
            case float n when n > 69 && n <= 103: 
                motorForce = 950;
                currentRPM = (speedometer.GetComponent<Speedometer>().speed / 103) * 7500;
                //gameObject.GetComponent<Rigidbody>().drag = 0.025f;
                break;
            case float n when n > 103 && n <= 140: 
                motorForce = 704;
                currentRPM = (speedometer.GetComponent<Speedometer>().speed / 140) * 7500;
                //gameObject.GetComponent<Rigidbody>().drag = 0.05f;
                break;
            case float n when n > 140 && n <= 182:
                motorForce = 538;
                currentRPM = (speedometer.GetComponent<Speedometer>().speed / 182) * 7500;
                //gameObject.GetComponent<Rigidbody>().drag = 0.1f;
                break;
            case float n when n > 182 && n <= 232:
                motorForce = 425;
                currentRPM = (speedometer.GetComponent<Speedometer>().speed / 232) * 7500;
                //gameObject.GetComponent<Rigidbody>().drag = 0.2f;
                break;
            case float n when n > 232 && n <= 290:
                motorForce = 337;
                currentRPM = (speedometer.GetComponent<Speedometer>().speed / 290) * 7500;
                //gameObject.GetComponent<Rigidbody>().drag = 0.2f;
                break;



        }
        {
            AkSoundEngine.SetRTPCValue("RPM", currentRPM);
        }
        if (isBreaking == true) {
            WheelFrictionCurve LsFriction = backLeftWheelCollider.sidewaysFriction;
            LsFriction.stiffness = 12f;
            backLeftWheelCollider.sidewaysFriction = LsFriction;
            WheelFrictionCurve RsFriction = backRightWheelCollider.sidewaysFriction;
            RsFriction.stiffness = 12f;
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
            motorForce /= 2f;
            if (currentGear > 1) {
                currentGear -= 1;
            }
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
        //wheelTransform.rotation = new Quaternion(0, 90, 0, 0);
        wheelTransform.position = pos;
    }
}
