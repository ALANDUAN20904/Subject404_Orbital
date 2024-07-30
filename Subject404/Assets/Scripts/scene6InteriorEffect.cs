using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scene6InteriorEffect : MonoBehaviour
{
    public AudioClip collisionSound;
    private AudioSource _audioSource;
    private bool _hasPlayed = false;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>(); 
        if (_audioSource == null)
        {
            _audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !_hasPlayed)
        {
            if (collisionSound != null && _audioSource != null)
            {
                _audioSource.PlayOneShot(collisionSound);
                _hasPlayed = true;
            }
            else
            {
                Debug.LogWarning("Collision sound or AudioSource is missing!");
            }
        }
    }

    
}
