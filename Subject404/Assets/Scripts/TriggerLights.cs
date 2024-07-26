using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLights : MonoBehaviour
{
    public GameObject topLights;
    public GameObject bottomLights;
    public GameObject sound;
    public GameObject gameSound;
    public GameObject gameInstructions;
    private StateManagerScene6 stateManager;
    
    void Start()
    {
        stateManager = gameInstructions.GetComponent<StateManagerScene6>();
    }
    void OnTriggerEnter(Collider other)
    {
        bottomLights.SetActive(false);
        sound.SetActive(true);
        topLights.SetActive(true);
        gameSound.SetActive(true);
        stateManager.SetSceneState(1);
    }
}
