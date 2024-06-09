using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextUpdater : MonoBehaviour
{
    public TMP_Text textField;
    public void UpdateText(ref string text)
    {
       textField.text = text;
    }
}
