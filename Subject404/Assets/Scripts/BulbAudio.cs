using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulbAudio : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] audioClips;
    private bool playedSparks = false;
    void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogWarning("Audio Source attached to " + gameObject.name + " not found, creating new");
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.spatialBlend = 1;
            audioSource.rolloffMode = AudioRolloffMode.Linear;
        }
    }
    public void PlaySparkAudio()
    {
        if (!playedSparks)
        {
            if (audioClips[0] != null)
            {
                audioSource.clip = audioClips[0];
                audioSource.loop = true;
                audioSource.Play();
                playedSparks = true;
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
            audioSource.loop = false;
            audioSource.clip = audioClips[1];
            audioSource.Play();
            yield return new WaitForSeconds(audioClips[1].length);
        }
        else
        {
            Debug.LogError("Audio Clip not attached to " + gameObject.name);
        }
    }
}
