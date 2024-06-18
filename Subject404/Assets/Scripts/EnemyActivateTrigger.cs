using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActivateTrigger : MonoBehaviour
{
    public GameObject gameInstructions;
    private StateManagerScene4 stateManager;
    bool enabledEnemy = false;
    void Start(){
        stateManager = gameInstructions.GetComponent<StateManagerScene4>();
    }
    void OnTriggerEnter(){
        if (!enabledEnemy){
            stateManager.enableEnemy();
            enabledEnemy = true;
        }
    }
}
