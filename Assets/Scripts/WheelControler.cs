using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelControler : MonoBehaviour
{

    [SerializeField] WheelCollider rearRight;
    [SerializeField] WheelCollider rearLeft;
    [SerializeField] WheelCollider frontRight;
    [SerializeField] WheelCollider frontLeft;

    [SerializeField] Transform rearRightTransform;
    [SerializeField] Transform rearLeftTransform;
    [SerializeField] Transform frontRightTransform;
    [SerializeField] Transform frontLeftTransform;

    public float acceleration = 500f;
    public float breakingForce = 300f;
    public float maxTurnAngle = 15f;


    private float currentAcceleration = 0f;
    private float currentBreakForce = 0f;
    private float currentTurnAngle = 0f;


    private void FixedUpdate()
    {
        
        currentAcceleration = acceleration * Input.GetAxis("Vertical");


        if (Input.GetKey(KeyCode.Space))
            currentBreakForce = breakingForce;
        else
            currentBreakForce = 0f;

        frontRight.motorTorque = currentAcceleration;
        frontLeft.motorTorque = currentAcceleration;



        rearRight.brakeTorque = currentBreakForce;
        rearLeft.brakeTorque = currentBreakForce;
        frontRight.brakeTorque = currentBreakForce;
        frontLeft.brakeTorque = currentBreakForce;

        currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");
        frontLeft.steerAngle = currentTurnAngle;
        frontRight.steerAngle = currentTurnAngle;


        UpdateWheel(rearRight, rearRightTransform);
        UpdateWheel(rearLeft, rearLeftTransform);
        UpdateWheel(frontRight, frontRightTransform);
        UpdateWheel(frontLeft, frontLeftTransform);
    }

    void UpdateWheel(WheelCollider col, Transform trans)
    {
        Vector3 position;
        Quaternion rotation;

        col.GetWorldPose(out position, out rotation);

        trans.position = position;
        trans.rotation = rotation;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
