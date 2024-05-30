using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    private TextUpdater textUpdater;
    private int sceneState = 0;
    public GameObject lampActive;
    private bool playedAudio = false;
    private bool interactedFridge = false;
    public void setInteractedFridge(){
        interactedFridge = true;
    }
    public void setPlayedAudio(){
        playedAudio = true;
    }

    string[] instructions = {"Grab lamp interactable to turn on lamp", "Walk towards the table", "Open the fridge", "Exit the house"};
    private void Awake(){
        textUpdater = GetComponent<TextUpdater>();
    }
    private void Update(){
        if (!lampActive.activeSelf) sceneState = 0;
        else if (!playedAudio) sceneState = 1;
        else if (!interactedFridge) sceneState = 2;
        else sceneState = 3;

        string text = instructions[sceneState];
        textUpdater.UpdateText(ref text);
    }
}
