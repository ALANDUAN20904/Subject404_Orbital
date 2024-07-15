
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguePlayerScene5 : MonoBehaviour
{
    private int _sceneState;
    public bool[] _flag;
    public AudioSource audioSource;
    public GameObject gameInstructions;
    public AudioClip[] audioClips;
    private StateManagerScene5 _stateManager;
    void Start()
    {
        _stateManager = gameInstructions.GetComponent<StateManagerScene5>();
        if (_stateManager == null)
        {
            Debug.LogError("State Manager not found");
        }
        if (audioSource == null)
        {
            Debug.LogError("Audio Source not set");
        }
    }

    private IEnumerator WaitAndUpdateState()
    {
        yield return new WaitForSeconds(audioClips[_sceneState].length);
        _stateManager.SetSceneState(_sceneState + 1);
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