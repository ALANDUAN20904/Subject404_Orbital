
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguePoliceman : MonoBehaviour
{
    private int _sceneState;
    public bool[] _flag;
    public AudioSource audioSource;
    public GameObject gameInstructions;
    public AudioClip[] audioClips;
    private StateManagerScene3 _stateManager;
    void Start()
    {
        _stateManager = gameInstructions.GetComponent<StateManagerScene3>();
        if (_stateManager == null)
        {
            Debug.LogError("State Manager not found");
        }
        if (audioSource == null)
        {
            Debug.LogError("Audio Source not set");
        }
        //_flag = new bool[] { true, false, true, false, true, true, true, true, true, true, true };
    }

    private IEnumerator WaitAndUpdateState()
    {
        yield return new WaitForSeconds(audioClips[_sceneState].length);
        _stateManager.SetSceneState(_sceneState + 1);
        Debug.Log("next state");
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
                StartCoroutine(WaitAndUpdateState());
            }
            else
            {
                Debug.LogError("Audio Clip not found");
            }
        }
    }

}