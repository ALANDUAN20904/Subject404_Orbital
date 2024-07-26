using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManagerScene6 : MonoBehaviour
{
    private int _sceneState = 0;
    private TextUpdater _textUpdater;
    private string[] _instructions = {"Walk", "Turn around and climb the ladder", "Enter the room"};

    public int GetSceneState()
    {
        return _sceneState;
    }

    public void SetSceneState(int sceneState)
    {
        _sceneState = sceneState;
    }
    void Start()
    {
        _textUpdater = GetComponent<TextUpdater>();
    }

    // Update is called once per frame
    void Update()
    {
        string text = _instructions[_sceneState];
        _textUpdater.UpdateText(ref text);
    }
}
