using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TestTools;
using TMPro;

public class TextUpdaterTest
{
    private TMP_Text _textField;
    public RectTransform panel;
    public GameObject UI;
    private Vector3 _originalScale;
    private Vector3 targetScale = new Vector3(0.5f, 0.5f, 0.5f);
    private float transitionDuration = 1.0f;
    private Vector3 _originalPosition;
    private Vector3 targetPosition = new Vector3(0, -40, 0);
    private TextUpdater _textUpdater;
    private string _text;
    private TMP_FontAsset _fontAsset;

    [SetUp]
    public void Setup()
    {
        GameObject stateManager = new GameObject("TestManager");
        _textUpdater = stateManager.AddComponent<TextUpdater>();
        GameObject textObject = new GameObject("TextObject");
        string fontAssetPath = "Assets/TextMesh Pro/Resources/Fonts & Materials/BlastineFont SDF.asset";
        _fontAsset = UnityEditor.AssetDatabase.LoadAssetAtPath<TMP_FontAsset>(fontAssetPath);
        _textField = textObject.AddComponent<TextMeshProUGUI>();
        _textField.font = _fontAsset;
        UI = new GameObject("UI");
        _textUpdater.UI = UI;
        panel = UI.AddComponent<RectTransform>();
        _textUpdater.panel = panel;
        _originalScale = panel.localScale;
        _originalPosition = panel.localPosition;

        if (_fontAsset == null)
        {
            Debug.LogWarning("Font Asset was not found. Please ensure the path is correct and the asset exists.");
        }

        _textUpdater.textField = _textField;
        _text = "updated string";
    }

    [Test]
    public void TextUpdateTest()
    {
        _textUpdater.UpdateText(ref _text);
        Assert.AreEqual(_text, _textField.text);
    }
}
