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

    void Start()
    {
        if (hasTorque)
        {
            rigidBody = GetComponent<Rigidbody>();
            if (rigidBody != null && torque != null)
            {
                rigidBody.AddTorque(torque, ForceMode.Impulse);
            }
            else
            {
                Debug.LogError("rigidBody or torque parameters not found");
            }
        }
        stateManager = gameInstructions.GetComponent<StateManagerScene4>();
        if (stateManager == null)
        {
            Debug.LogError("State Manager not found");
        }
        if (endPos == null)
        {
            Debug.LogError("End Position not set");
        }
    }
    void Update()
    {
        var step = speed * Time.deltaTime;
        if (Vector3.Distance(transform.position, endPos.position) < 0.001f)
        {
            if (!hasReached)
            {
                if (hasTorque)
                {
                    rigidBody.angularVelocity = Vector3.zero;
                }
                if (gameObject.name == "Ghoul (1)")
                {
                    stateManager.DisableParkEnemy();
                }
                hasReached = true;
            }
            stateManager.EnableAxeInteraction();
        }
        if (!hasReached)
        {
            if (hasLinearVel)
            {
                transform.position = Vector3.MoveTowards(transform.position, endPos.position, step);
            }
        }
    }
}
