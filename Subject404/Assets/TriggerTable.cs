using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTable : MonoBehaviour
{
    private StateManager stateManager;
    public GameObject gameInstructions;
    private void Awake(){
        stateManager = gameInstructions.GetComponent<StateManager>();
    }
    private void OnTriggerEnter(Collider other){
        stateManager.playNewsAudio();
    }
}
