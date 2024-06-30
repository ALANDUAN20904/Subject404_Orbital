using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class StateManagerScene3 : MonoBehaviour
{
    private int _sceneState = 0;
    public GameObject DoorKnob;
    public GameObject Milk;
    public GameObject Policeman;
    private DialoguePoliceman _policeDialogue;
    private bool _triggeredAudio = false;
    private bool _playedAudio = false;
    private AudioSource _audioSources;
    private ToggleInteraction _toggleInteraction;
    private bool _grabbedMilk = false;
    private bool _putDownMilk = false;
    private TextUpdater _textUpdater;
    string[] _instructions = {"Grab a milk","","","","","Put the milk down at the cashier","","","","","Grab door knob to exit" };


    void Start()
    {
        _policeDialogue = Policeman.GetComponent<DialoguePoliceman>();
    }

    private void Awake()
    {
        
        _textUpdater = GetComponent<TextUpdater>();
        if (_textUpdater == null)
        {
            Debug.LogError("Text Updater component not found");
        }
        
        _sceneState = 0;
    }

    public int GetSceneState()
    {
        return _sceneState;
    }
    public void SetSceneState(int state)
    {
        _sceneState = state;
    }
    public void SetGrabbedMilk()
    {
        _grabbedMilk = true;
    }

    public void SetPutDownMilk()
    {
        _putDownMilk = true;
    }


    void Update()
    {
        string text = _instructions[_sceneState];
        _textUpdater.UpdateText(ref text);

        if (_grabbedMilk)
        {
            _sceneState = 1;
        }
        else if (_putDownMilk)
        {
            _sceneState = 5;
        }

      
    }






}
