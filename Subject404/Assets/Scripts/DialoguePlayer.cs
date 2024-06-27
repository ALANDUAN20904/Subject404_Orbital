using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguePlayer : MonoBehaviour
{
    public AudioSource audioSource;
    private StateManager _stateManager;
    public GameObject gameInstructions;
    private int _sceneState;
    private bool[] _flag;
    public AudioClip[] audioClips;
    void Start()
    {
        _stateManager = gameInstructions.GetComponent<StateManager>();
        if (_stateManager == null)
        {
            Debug.LogError("State Manager not found");
        }
        if (audioSource == null)
        {
            Debug.LogError("Audio Source not set");
        }
        _flag = new bool[] { false, false, true, false, false };
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
