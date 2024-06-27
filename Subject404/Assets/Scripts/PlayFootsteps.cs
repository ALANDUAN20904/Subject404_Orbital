using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFootsteps : MonoBehaviour
{
    private Vector3 _prevPos;
    private Vector3 _currPos;
    private AudioSource _audioSource;
    private bool _isPlaying;
    void Start()
    {
        _prevPos = transform.position;
        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
        {
            Debug.LogError("Audio Source not found");
        }
        _isPlaying = false;
    }

    void Update()
    {
        _isPlaying = _audioSource.isPlaying;
        _currPos = transform.position;
        if (_currPos != _prevPos)
        {
            if (!_isPlaying) _audioSource.Play();
        }
        else _audioSource.Pause();
        _prevPos = _currPos;
    }
}
