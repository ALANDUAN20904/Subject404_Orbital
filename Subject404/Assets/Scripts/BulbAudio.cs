using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulbAudio : MonoBehaviour
{
    private AudioSource _audioSource;
    public AudioClip[] audioClips;
    private bool _playedSparks = false;
    void Awake()
    {
        _audioSource = gameObject.GetComponent<AudioSource>();
        if (_audioSource == null)
        {
            Debug.LogWarning("Audio Source attached to " + gameObject.name + " not found, creating new");
            _audioSource = gameObject.AddComponent<AudioSource>();
            _audioSource.spatialBlend = 1;
            _audioSource.rolloffMode = AudioRolloffMode.Linear;
        }
    }
    public void PlaySparkAudio()
    {
        if (!_playedSparks)
        {
            if (audioClips[0] != null)
            {
                _audioSource.clip = audioClips[0];
                _audioSource.loop = true;
                _audioSource.Play();
                _playedSparks = true;
            }
            else
            {
                Debug.LogError("Audio Clip not attached to " + gameObject.name);
            }
        }
    }
    public IEnumerator PlayExplosion()
    {
        if (audioClips[1] != null)
        {
            _audioSource.loop = false;
            _audioSource.clip = audioClips[1];
            _audioSource.Play();
            yield return new WaitForSeconds(audioClips[1].length);
        }
        else
        {
            Debug.LogError("Audio Clip not attached to " + gameObject.name);
        }
    }
}
