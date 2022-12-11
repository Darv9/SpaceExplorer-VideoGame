using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField]
    float speed = 100.0F;

    [SerializeField]
    float torque = 1000.0F;

    [SerializeField]
    float lowerAngle = -70.0F;

    [SerializeField]
    float higherAngle = 70.0F;

    Rigidbody2D rb;
    HingeJoint2D joint;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        joint = GetComponent<HingeJoint2D>();

        joint.useMotor = true;
        JointMotor2D motor = joint.motor;
        motor.motorSpeed = speed;
        motor.maxMotorTorque = torque;
        joint.motor = motor;

        joint.useLimits = true;
        JointAngleLimits2D angleLimits = joint.limits;
        angleLimits.min = lowerAngle;
        angleLimits.max = higherAngle;
        joint.limits = angleLimits;
    }

    private void Update()
    {
        if (joint.jointAngle <= lowerAngle || joint.jointAngle >= higherAngle)
        {
            JointMotor2D motor = joint.motor;
            motor.motorSpeed *= -1;
            joint.motor = motor;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<CombateJudador>().TomarDano(20);
        }
    }
}
