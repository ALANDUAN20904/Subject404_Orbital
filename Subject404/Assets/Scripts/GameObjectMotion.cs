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
    private Rigidbody _rigidBody;
    private bool _hasReached = false;
    public GameObject gameInstructions;
    private StateManagerScene4 _stateManager;

    void Start()
    {
        if (hasTorque)
        {
            _rigidBody = GetComponent<Rigidbody>();
            if (_rigidBody != null && torque != null)
            {
                _rigidBody.AddTorque(torque, ForceMode.Impulse);
            }
            else
            {
                Debug.LogError("rigidBody or torque parameters not found");
            }
        }
        _stateManager = gameInstructions.GetComponent<StateManagerScene4>();
        if (_stateManager == null)
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
            if (!_hasReached)
            {
                if (hasTorque)
                {
                    _rigidBody.angularVelocity = Vector3.zero;
                }
                if (gameObject.name == "Ghoul (1)")
                {
                    _stateManager.DisableParkEnemy();
                }
                _hasReached = true;
            }
            _stateManager.EnableAxeInteraction();
        }
        if (!_hasReached)
        {
            if (hasLinearVel)
            {
                transform.position = Vector3.MoveTowards(transform.position, endPos.position, step);
            }
        }
    }
}
