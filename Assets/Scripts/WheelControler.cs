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

    public float acceleration = 400f;
    public float breakingForce = 300f;
    public float maxTurnAngle = 15f;

    private float currentAcceleration = 0f;
    private float currentBreakForce = 0f;
    private float currentTurnAngle = 0f;

    private int startOrStop = 0;
    private int leftOrRight = 0;

    private void FixedUpdate()
    {
        currentAcceleration = acceleration * startOrStop;

        frontRight.motorTorque = currentAcceleration;
        frontLeft.motorTorque = currentAcceleration;

        rearRight.brakeTorque = currentBreakForce;
        rearLeft.brakeTorque = currentBreakForce;
        frontRight.brakeTorque = currentBreakForce;
        frontLeft.brakeTorque = currentBreakForce;

        currentTurnAngle = maxTurnAngle * leftOrRight;
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

        rotation *= Quaternion.Euler(0, -90, 0);
        trans.rotation = rotation;
    }

    // Buttons controls
    public void OnGasPress()
    {
        startOrStop = 1;
    }

    public void OnGasRelease()
    {
        startOrStop = 0;
    }
    public void OnBrakePress()
    {
        currentBreakForce = breakingForce;
    }

    public void OnBrakeRelease()
    {
        currentBreakForce = 0f;
    }

    public void OnLeftPress()
    {
        leftOrRight = -1;
    }

    public void OnLeftRelease()
    {
        leftOrRight = 0;
    }

    public void OnRightPress()
    {
        leftOrRight = 1;
    }

    public void OnRightRelease()
    {
        leftOrRight = 0;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Arrival")
        {
            other.gameObject.SetActive(false);
            GameObject.Find("Car Controls").gameObject.SetActive(false);
            GameObject.Find("Win Menu Container").transform.Find("Win Menu").gameObject.SetActive(true);
            GameManager.Manager.StopTimer();
        }
    }
}