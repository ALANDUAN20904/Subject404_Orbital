using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class StateManagerScene8 : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject material;
    public VideoClip[] videoClips;
    public bool isSafe = false;

    void Awake()
    {
        material.SetActive(true);
    }    
    void Start()
    {
        if (!isSafe)
        {
            videoPlayer.clip = videoClips[0];
        }
        else{
            videoPlayer.clip = videoClips[1];
        }
        videoPlayer.Play();
    }
}
