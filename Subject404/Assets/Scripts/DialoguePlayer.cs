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
        if (stateManager == null){
            Debug.LogError("State Manager not found");
        }
        if (audioSource == null){
            Debug.LogError("Audio Source not set");
        }
        flag = new bool[] {false, false, true, false, false};
    }
    void Update(){
        sceneState = stateManager.getSceneState();
        if (!flag[sceneState]){
            flag[sceneState] = true;
            if (audioClips[sceneState] != null){
                audioSource.clip = audioClips[sceneState];
                audioSource.Play();
            }
            else{
                Debug.LogError("Audio Clip not found");
            }
        }
    }
}
