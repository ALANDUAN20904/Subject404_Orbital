using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeMotion : MonoBehaviour
{
    public float speed = 10.0f;
    private bool isStatic = false;
    public Vector3 torque;
    public Transform endPos;
    private Rigidbody rigidBody;
    private bool hasReached = false;
    public GameObject gameInstructions;
    private StateManagerScene4 stateManager;

    void Start(){
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.AddTorque(torque, ForceMode.Impulse);
        stateManager = gameInstructions.GetComponent<StateManagerScene4>();
    }
    void Update()
    {
        var step = speed * Time.deltaTime;
        if (!hasReached){
            transform.position = Vector3.MoveTowards(transform.position, endPos.position, step);
        }
        if (Vector3.Distance(transform.position, endPos.position) < 0.001f){
            hasReached = true;
            if (!isStatic){
                rigidBody.angularVelocity = Vector3.zero;
                isStatic = true;
            }
            stateManager.enableAxeInteraction();
        }
    }
}
