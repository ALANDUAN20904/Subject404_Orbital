using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using TMPro;

public class Scene1StateTests
{
    private StateManager _stateManager;
    private TextUpdater _textUpdater;
    private TMP_Text _textField;
     public RectTransform panel;
    public GameObject UI;
    private Vector3 _originalScale;
    private Vector3 targetScale = new Vector3(0.5f, 0.5f, 0.5f);
    private float transitionDuration = 1.0f;
    private Vector3 _originalPosition;
    private Vector3 targetPosition = new Vector3(0, -40, 0);
    private GameObject _manager;
    private GameObject _lamp;
    private GameObject _fridgeRDoor;
    private GameObject _mainDoor;
    private GameObject _radio;

    [SetUp]
    public void SetUp()
    {
        _manager = new GameObject("Manager");
        _textUpdater = _manager.AddComponent<TextUpdater>();
        GameObject textObject = new GameObject("TextObject");
        _textField = textObject.AddComponent<TextMeshProUGUI>();
        UI = new GameObject("UI");
        _textUpdater.UI = UI;
        panel = UI.AddComponent<RectTransform>();
        _textUpdater.panel = panel;
        _originalScale = panel.localScale;
        _originalPosition = panel.localPosition;

        _textUpdater.textField = _textField;
        _stateManager = _manager.AddComponent<StateManager>();

        _lamp = new GameObject("Lamp");
        _stateManager.lampActive = _lamp;

        _fridgeRDoor = new GameObject("FridgeRDoor");
        _stateManager.fridgeRDoor = _fridgeRDoor;

        _mainDoor = new GameObject("MainDoor");
        _stateManager.mainDoor = _mainDoor;

        _radio = new GameObject("Radio");
        _stateManager.radio = _radio;
    }

    private void CreateState(bool[] state)
    {
        _stateManager.lampActive.SetActive(state[0]);
        if (state[1])
        {
            _stateManager.SetTriggered();
        }
        if (state[2])
        {
            _stateManager.SetPlayedAudio();
        }
        if (state[3])
        {
            _stateManager.SetInteractedFridge();
        }
    }

    private int GetState(bool[] state)
    {
        for (int i = 0; i < state.Length; i++)
        {
            if (!state[i])
            {
                return i;
            }
        }
        return state.Length;
    }

    [UnityTest]
    public IEnumerator Scene1StateTestsSimplePassesTrue()
    {
        bool[] state = new bool[] { true, true, true, true };
        CreateState(state);

        yield return new WaitForSeconds(0.1f);

        Assert.AreEqual(GetState(state), _stateManager.GetSceneState());
    }
    [UnityTest]
    public IEnumerator Scene1StateTestsSimplePassesFalse()
    {
        bool[] state = new bool[] { false, false, false, false };
        CreateState(state);

        yield return new WaitForSeconds(0.1f);

        Assert.AreEqual(GetState(state), _stateManager.GetSceneState());
    }
    [UnityTest]
    public IEnumerator Scene1StateTestsStaggeredTrue()
    {
        bool[] state = new bool[] { true, false, true, false };
        CreateState(state);

        yield return new WaitForSeconds(0.1f);

        Assert.AreEqual(GetState(state), _stateManager.GetSceneState());
    }
    [UnityTest]
    public IEnumerator Scene1StateTestsSimpleStaggeredFalse()
    {
        bool[] state = new bool[] { false, true, false, true };
        CreateState(state);

        yield return new WaitForSeconds(0.1f);

        Assert.AreEqual(GetState(state), _stateManager.GetSceneState());
    }
}
