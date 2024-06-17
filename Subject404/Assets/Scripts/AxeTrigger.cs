using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeTrigger : MonoBehaviour
{
    private StateManagerScene4 stateManager;
    public GameObject gameInstructions;
    private void Awake(){
        stateManager = gameInstructions.GetComponent<StateManagerScene4>();
    }
    private void OnTriggerEnter(Collider other){
        stateManager.setCollided();
    }
}
