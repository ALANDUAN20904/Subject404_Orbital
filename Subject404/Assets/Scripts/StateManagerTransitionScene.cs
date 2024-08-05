using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManagerTransitionScene : MonoBehaviour
{
    private TextUpdater _textUpdater;
    private int _sceneState = 0;
    private int _prevState = -1;
    private bool _interactedFridge = false;
    private ToggleInteraction _toggleInteraction;
    public GameObject lampActive;
    public GameObject fridgeRDoor;
    public GameObject mainDoor;
    public void SetInteractedFridge()
    {
        _interactedFridge = true;
    }
    public int GetSceneState()
    {
        return _sceneState;
    }
    public void EnableFridgeInteraction()
    {
        if (fridgeRDoor != null)
        {
            _toggleInteraction = fridgeRDoor.GetComponent<ToggleInteraction>();
            if (_toggleInteraction != null)
            {
                _toggleInteraction.EnableObjectInteraction();
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
            _toggleInteraction = mainDoor.GetComponent<ToggleInteraction>();
            if (_toggleInteraction != null)
            {
                _toggleInteraction.EnableObjectInteraction();
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
    string[] _instructions = { "Grab lamp interactable to turn on lamp", "Grab the handle and open the fridge", "Grab the main door handle to exit the house" };
    private void Awake()
    {
        _textUpdater = GetComponent<TextUpdater>();
        if (_textUpdater == null)
        {
            Debug.LogError("Text Updater component not found");
        }
    }
    private void Update()
    {
        if (_sceneState != _prevState)
        {
            string text = _instructions[_sceneState];
            _textUpdater.UpdateText(ref text);
            _prevState = _sceneState;
        }
        if (!lampActive.activeSelf)
        {
            _sceneState = 0;
        }
        else if (!_interactedFridge){
            _sceneState = 1;
        }
        else{
            _sceneState = 2;
        }
    }
}
