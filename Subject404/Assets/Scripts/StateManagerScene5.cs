using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class StateManagerScene5 : MonoBehaviour
{
    private int _sceneState = 0;
    private int _prevState = -1;
    public GameObject DoorKnob;
    private bool _grabbedJuice = false;
    private bool _putDownJuice = false;
    private TextUpdater _textUpdater;
    private ToggleInteraction _toggleInteraction;
    string[] _instructions = { "", "Grab juice", "Put the juice down at the cashier", "", "Grab door knob to exit" };

    private void Awake()
    {
        _textUpdater = GetComponent<TextUpdater>();
        if (_textUpdater == null)
        {
            Debug.LogError("Text Updater component not found");
        }
        _toggleInteraction = DoorKnob.GetComponent<ToggleInteraction>();
    }
    public int GetSceneState()
    {
        return _sceneState;
    }
    public void SetSceneState(int state)
    {
        _sceneState = state;
    }
    public void SetGrabbedJuice()
    {
        _grabbedJuice = true;
    }
    public void SetPutDownJuice()
    {
        _putDownJuice = true;
    }
    void Update()
    {
        if (_sceneState != _prevState)
        {
            string text = _instructions[_sceneState];
            _textUpdater.UpdateText(ref text);
            _prevState = _sceneState;
        }

        if (_grabbedJuice && _sceneState == 1)
        {
            _sceneState = 2;
        }
        if (_putDownJuice && _sceneState == 2)
        {
            _sceneState = 3;
        }
        if (_sceneState == 4)
        {
            _toggleInteraction.EnableObjectInteraction();
        }
    }
}
