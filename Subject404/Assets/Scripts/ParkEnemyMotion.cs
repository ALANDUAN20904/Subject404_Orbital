using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkEnemyMotion : MonoBehaviour
{
    public GameObject gameInstructions;
    private StateManagerScene4 stateManager;
    private bool displayed = false;
    void Start()
    {
        stateManager = gameInstructions.GetComponent<StateManagerScene4>();
    }

    void OnTriggerEnter(){
        if (!displayed){
            displayed = true;
            stateManager.activateParkEnemy();
        }
    }
}
