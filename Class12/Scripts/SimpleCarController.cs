using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SimpleCarController : MonoBehaviour
{
    private Rigidbody m_Rigidbody;
    private float motor;
    private float steering;

    public List<AxleInfo> axleInfos;
    public float maxMotorTorque;
    public float maxSteeringAngle;

    public float m_Topspeed = 200;

    public Text carSpeed;

    [HideInInspector]
    public float velocity;

    [HideInInspector]
    public float acceleration;

    public void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    public void Update()
    {

         motor = maxMotorTorque * Input.GetAxis("Vertical");
         steering = maxSteeringAngle * Input.GetAxis("Horizontal");
    }

    // finds the corresponding visual wheel
    // correctly applies the transform
    public void ApplyLocalPositionToVisuals(WheelCollider collider)
    {
        if (collider.transform.childCount == 0)
        {
            return;
        }

        Transform visualWheel = collider.transform.GetChild(0);

        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }

    public void FixedUpdate()
    {

        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;

                acceleration = Mathf.Clamp(motor, 0, 1);
            }

            ApplyLocalPositionToVisuals(axleInfo.leftWheel);
            ApplyLocalPositionToVisuals(axleInfo.rightWheel);
        }

        CapSpeed();
    }

    private void CapSpeed()
    {
        float speed = m_Rigidbody.velocity.magnitude;
        
                speed *= 3.6f;
                if (speed > m_Topspeed)
                    m_Rigidbody.velocity = (m_Topspeed / 3.6f) * m_Rigidbody.velocity.normalized;

        velocity = m_Rigidbody.velocity.magnitude;

        carSpeed.text = m_Rigidbody.velocity.magnitude.ToString("F2") + " KMH";


    }
}


[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor;
    public bool steering;
}

