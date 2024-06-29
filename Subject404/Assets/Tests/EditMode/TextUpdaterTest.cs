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
