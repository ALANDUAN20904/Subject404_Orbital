using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionDialogue : MonoBehaviour
{
    private int _sceneState;
    private bool[] _flag;
    private StateManagerTransitionScene _stateManager;
    public AudioSource audioSource;
    public GameObject gameInstructions;
    public AudioClip[] audioClips;
    void Start()
    {
        _stateManager = gameInstructions.GetComponent<StateManagerTransitionScene>();
        if (_stateManager == null)
        {
            Debug.LogError("State Manager not found");
        }
        if (audioSource == null)
        {
            Debug.LogError("Audio Source not set");
        }
        _flag = new bool[] { false, false, false};
    }
    void Update()
    {
        _sceneState = _stateManager.GetSceneState();
        if (!_flag[_sceneState])
        {
            _flag[_sceneState] = true;
            if (audioClips[_sceneState] != null)
            {
                audioSource.clip = audioClips[_sceneState];
                audioSource.Play();
            }
            else
            {
                Debug.LogError("Audio Clip not found");
            }
        }
    }
}
