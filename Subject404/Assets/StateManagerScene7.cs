using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class StateManagerScene7 : MonoBehaviour
{
    private int _sceneState = 0;
    private TextUpdater _textUpdater;
    string[] _instructions = { "Find a barrel to hide!", "Find and open Exit door","Go to exit!"};
    private bool _interactedDoorKnob2 =  false; 
    private bool _interactedSafeZone = false;
    
    private void Awake()
    {
        _textUpdater = GetComponent<TextUpdater>();
        if (_textUpdater == null)
        {
            Debug.LogError("Text Updater component not found");
        }
        else
        {
            UpdateInstructions();
        }
    }

    public int GetSceneState()
    {
        return _sceneState;
    }

    public void SetSceneState(int state)
    {
        _sceneState = state;
        UpdateInstructions();
    }

    public void SetInteractedSafeZone()
    {
       if ( !_interactedSafeZone && _sceneState == 0)
        {
            _interactedSafeZone = true;
            SetSceneState(1);
        }
    }

    public void SetInteractedDoorKnob2()
    {
        if (!_interactedDoorKnob2 && _sceneState == 1)
        {
            _interactedDoorKnob2 = true;
            SetSceneState(2);
        }
    }

    void UpdateInstructions()
    {
        string text = _instructions[_sceneState];
        _textUpdater.UpdateText(ref text);        
    }

    
}
