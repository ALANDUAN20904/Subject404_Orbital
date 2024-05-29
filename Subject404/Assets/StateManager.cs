using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    private TextUpdater textUpdater;
    public int sceneState = 0;
    string[] instructions = {"Grab lamp interactable to turn on lamp", "Walk towards the table"};
    private void Awake(){
        textUpdater = GetComponent<TextUpdater>();
    }
    private void Update(){
        string text = instructions[sceneState];
        textUpdater.UpdateText(ref text);
    }
}
