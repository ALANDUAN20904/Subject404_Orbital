using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeMotion : MonoBehaviour
{
    public float speed = 10.0f;
    public Vector3 torque;
    public Transform endPos;
    private Rigidbody rigidBody;
    private bool hasReached = false;

    void Start(){
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.AddTorque(torque, ForceMode.Impulse);
    }
    void Update()
    {
        var step = speed * Time.deltaTime;
        if (!hasReached){
            transform.position = Vector3.MoveTowards(transform.position, endPos.position, step);
        }
        if (Vector3.Distance(transform.position, endPos.position) < 0.001f){
            hasReached = true;
            rigidBody.angularVelocity = Vector3.zero;
        }
    }
}
