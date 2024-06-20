using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectMotion : MonoBehaviour
{
    public float speed = 10.0f;
    public bool hasTorque = false;
    public bool hasLinearVel = true;
    public Vector3 torque;
    public Transform endPos;
    private Rigidbody rigidBody;
    private bool hasReached = false;
    public GameObject gameInstructions;
    private StateManagerScene4 stateManager;

    void Start(){
        if (hasTorque){
            rigidBody = GetComponent<Rigidbody>();
            rigidBody.AddTorque(torque, ForceMode.Impulse);
        }
        stateManager = gameInstructions.GetComponent<StateManagerScene4>();
    }
    void Update()
    {
        var step = speed * Time.deltaTime;
        if (Vector3.Distance(transform.position, endPos.position) < 0.001f){
            if (!hasReached){
                if (hasTorque){
                    rigidBody.angularVelocity = Vector3.zero;
                }
                if (gameObject.name == "Ghoul (1)"){
                    stateManager.disableParkEnemy();
                }
                hasReached = true;
            }
            stateManager.enableAxeInteraction();
        }
        if (!hasReached){
            if (hasLinearVel){
                transform.position = Vector3.MoveTowards(transform.position, endPos.position, step);
            }
        } 
    }
}
