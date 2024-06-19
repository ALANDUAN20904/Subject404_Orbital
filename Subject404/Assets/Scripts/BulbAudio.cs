using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulbAudio : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] audioClips; 
    private bool playedSparks = false;
    void Awake(){
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    public void playSparkAudio(){
        if (!playedSparks){
            audioSource.clip = audioClips[0];
            audioSource.loop = true;
            audioSource.Play();
            playedSparks = true;
        }
    }
    public IEnumerator playExplosion(){
        audioSource.loop = false;
        audioSource.clip = audioClips[1];
        audioSource.Play();
        yield return new WaitForSeconds(2.5f);
    }
}
