using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    private TextUpdater textUpdater;
    private int sceneState = 0;
    public GameObject lampActive;
    public GameObject fridgeRDoor;
    public GameObject mainDoor;
    public GameObject radio;
    private bool triggeredAudio = false;
    private bool playedAudio = false;
    private bool interactedFridge = false;
    private ToggleInteraction toggleInteraction;
    private AudioSource[] audioSources;
    public void SetInteractedFridge()
    {
        interactedFridge = true;
    }
    public void PlayNewsAudio()
    {
        StartCoroutine(PlayAudioAndWait());
    }
    public int GetSceneState()
    {
        return sceneState;
    }

    private IEnumerator PlayAudioAndWait()
    {
        if (radio != null)
        {
            audioSources = radio.GetComponents<AudioSource>();
            if (audioSources == null)
            {
                Debug.LogError("Audio Source components not found");
            }
            audioSources[1].enabled = false;
            yield return new WaitForSeconds(2);
            audioSources[0].enabled = true;
            triggeredAudio = true;
            yield return new WaitForSeconds(40);
            playedAudio = true;
            EnableFridgeInteraction();
        }
        else
        {
            Debug.LogError("Radio GameObject not set");
        }
    }
    public void EnableFridgeInteraction()
    {
        if (fridgeRDoor != null)
        {
            toggleInteraction = fridgeRDoor.GetComponent<ToggleInteraction>();
            if (toggleInteraction != null)
            {
                toggleInteraction.EnableObjectInteraction();
            }
            else
            {
                Debug.LogError("Toggle Interaction Component not found on fridgeRDoor");
            }
        }
        else
        {
            Debug.LogError("fridgeRDoor GameObject not set");
        }
    }
    public void EnableDoorInteraction()
    {
        if (mainDoor != null)
        {
            toggleInteraction = mainDoor.GetComponent<ToggleInteraction>();
            if (toggleInteraction != null)
            {
                toggleInteraction.EnableObjectInteraction();
            }
            else
            {
                Debug.LogError("Toggle Interaction Component not found on main door");
            }
        }
        else
        {
            Debug.LogError("Main Door GameObject not set");
        }
    }
    string[] instructions = { "Grab lamp interactable to turn on lamp", "Walk towards the table", "", "Grab the handle and open the fridge", "Grab the main door handle to exit the house" };
    private void Awake()
    {
        textUpdater = GetComponent<TextUpdater>();
        if (textUpdater == null)
        {
            Debug.LogError("Text Updater component not found");
        }
    }
    private void Update()
    {
        if (!lampActive.activeSelf) sceneState = 0;
        else if (!triggeredAudio) sceneState = 1;
        else if (!playedAudio) sceneState = 2;
        else if (!interactedFridge) sceneState = 3;
        else sceneState = 4;

        string text = instructions[sceneState];
        textUpdater.UpdateText(ref text);
    }
}
