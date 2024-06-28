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

    [SetUp]
    public void Setup()
    {
        GameObject stateManager = new GameObject("TestManager");
        _textUpdater = stateManager.AddComponent<TextUpdater>();
        GameObject textObject = new GameObject("TextObject");
        _textField = textObject.AddComponent<TextMeshProUGUI>();
        string fontAssetPath = "Assets/TextMeshPro/Resources/Fonts & Materials/BlastineFont SDF.asset";
        _textField.font = UnityEditor.AssetDatabase.LoadAssetAtPath<TMP_FontAsset>(fontAssetPath);

        _textUpdater.textField = _textField;
        _text = "updated string";
    }

    [Test]
    public void TextUpdateTest()
    {
        // Perform the text update
        _textUpdater.UpdateText(ref _text);

        // Assert the result
        Assert.AreEqual("test string", _textField.text);
    }
}
