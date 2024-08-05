using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextUpdater : MonoBehaviour
{
    public TMP_Text textField;
    public RectTransform panel;
    public GameObject UI;
    private Vector3 _originalScale;
    private Vector3 targetScale = new Vector3(0.5f, 0.5f, 0.5f);
    private float transitionDuration = 1.0f;
    private Vector3 _originalPosition;
    private Vector3 targetPosition = new Vector3(0, -40, 0);

    public void Start()
    {
        _originalScale = panel.localScale;
        _originalPosition = panel.localPosition;
    }
    public void UpdateText(ref string text)
    {
        if (text == "")
        {
            UI.SetActive(false);
        }
        else{
            UI.SetActive(true);
            StartCoroutine(ScaleTo());
            textField.text = text;
        }
    }

    private IEnumerator ScaleTo()
    {
        float elapsedTime = 0f;
        while (elapsedTime < transitionDuration)
        {
            panel.localScale = Vector3.Lerp(_originalScale, targetScale, elapsedTime / transitionDuration);
            panel.localPosition = Vector3.Lerp(_originalPosition, targetPosition, elapsedTime / transitionDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        panel.localScale = targetScale;
        panel.localPosition = targetPosition;

        yield return new WaitForSeconds(1);

        elapsedTime = 0f;

        while (elapsedTime < transitionDuration)
        {
            panel.localScale = Vector3.Lerp(targetScale, _originalScale, elapsedTime / transitionDuration);
            panel.localPosition = Vector3.Lerp(targetPosition, _originalPosition, elapsedTime / transitionDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        panel.localScale = _originalScale;
        panel.localPosition = _originalPosition;
    }
}
