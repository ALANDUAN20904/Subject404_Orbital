using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMotion : MonoBehaviour
{
    public float speed = 10.0f;
    public Transform endPos;
    private bool hasReached = false;
    public GameObject gameInstructions;
    private StateManagerScene4 stateManager;

    void Start(){
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
            stateManager.disableParkEnemy();
        }
    }
}
