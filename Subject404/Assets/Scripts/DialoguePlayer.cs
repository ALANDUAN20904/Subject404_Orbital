using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguePlayer : MonoBehaviour
{
    public AudioSource audioSource;
    private StateManager stateManager;
    public GameObject gameInstructions;
    private int sceneState;
    private bool[] flag;
    public AudioClip[] audioClips; 
    void Start(){
        stateManager = gameInstructions.GetComponent<StateManager>();
        flag = new bool[] {false, false, true, false, false};
    }
    void Update(){
        sceneState = stateManager.getSceneState();
        if (!flag[sceneState]){
            flag[sceneState] = true;
            audioSource.clip = audioClips[sceneState];
            audioSource.Play();
        }
    }
}
