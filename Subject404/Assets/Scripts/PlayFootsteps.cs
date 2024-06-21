using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFootsteps : MonoBehaviour
{
    private Vector3 prevPos;
    private Vector3 currPos;
    private AudioSource audioSource;
    private bool isPlaying;
    void Start()
    {
        prevPos = transform.position;
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null){
            Debug.LogError("Audio Source not found");
        }
        isPlaying = false;
    }

    void Update()
    {
        isPlaying = audioSource.isPlaying;
        currPos = transform.position;
        if (currPos != prevPos){
            if (!isPlaying) audioSource.Play();
        }
        else audioSource.Pause();
        prevPos = currPos;
    }
}
