using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class StateManagerScene8 : MonoBehaviour
{
    private bool _isSafe;
    public VideoPlayer videoPlayer;
    public GameObject material;
    public VideoClip[] videoClips;

    void Awake()
    {
        material.SetActive(true);
    }    
    void Start()
    {
        if (MainManager.Instance != null)
        {
            _isSafe = MainManager.Instance.GetSafe();
            if (!_isSafe)
            {
                videoPlayer.clip = videoClips[0];
            }
            else{
                videoPlayer.clip = videoClips[1];
            }
            videoPlayer.Play();
        }
        else
        {
            Debug.LogError("MainManager instance is not available");
        }
    }
}
