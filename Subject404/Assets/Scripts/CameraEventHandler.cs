using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class CameraEventHandler : MonoBehaviour
{
    public InputActionReference captureAction;
    public GameObject captureFlash;
    public GameObject lightFlash;

    private void OnEnable()
    {
        captureAction.action.performed += OnCapture;
    }

    private void OnDisable()
    {
        captureAction.action.performed -= OnCapture;
    }

    private void OnCapture(InputAction.CallbackContext context)
    {
        StartCoroutine(Capture());
    }

    private IEnumerator Capture()
    {
        captureFlash.SetActive(true);
        lightFlash.SetActive(true);
        yield return new WaitForSeconds(1);
        lightFlash.SetActive(false);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(8);
    }
}