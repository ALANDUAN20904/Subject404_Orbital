using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CultistAudioManager : MonoBehaviour
{
    public AudioSource cultistAudioSource;
    public AudioSource playerAudioSource;
    public AudioClip[] stateClips;

    private AiAgent aiAgent;
    private AiStateId currentState;

    void Start()
    {
        aiAgent = GetComponent<AiAgent>();

        currentState = AiStateId.Patrol;
        SetAudio(currentState);
    }

   
    void Update()
    {
        AiStateId newState = aiAgent.stateMachine.currentState;
        if (newState != currentState )
        {
            currentState = newState;
            SetAudio(currentState);
        }
    }

    void SetAudio(AiStateId stateId)
    {
        int clipIndex = (int)stateId;
        if (clipIndex >= stateClips.Length || stateClips[clipIndex] == null)
        {
            //debug 
            Debug.LogWarning("Invalid audio clip for state: " + stateId);
            return;
        }

        if (cultistAudioSource.clip != stateClips[clipIndex])
        {
            cultistAudioSource.clip = stateClips[clipIndex];
            cultistAudioSource.Play();
        }

        if (stateId == AiStateId.Patrol)
        {
            PlayBGM();
        }
        else
        {
            StopBGM();
        }
    }

    void PlayBGM()
    {
        if (!playerAudioSource.isPlaying)
        {
            playerAudioSource.Play();
        }
    }

    void StopBGM()
    {
        if (playerAudioSource.isPlaying) 
        { 
            playerAudioSource.Stop();   
        }
    }



}
