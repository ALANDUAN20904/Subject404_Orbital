using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorActivateTrigger : MonoBehaviour
{
    public GameObject gameInstructions;
    private StateManagerScene4 stateManager;
    private bool activatedMirror = false;
    void Start()
    {
        stateManager = gameInstructions.GetComponent<StateManagerScene4>();
    }

    void OnTriggerEnter(){
        if (!activatedMirror){
            stateManager.activateMirror();
            activatedMirror = true;
        }
    }
}
