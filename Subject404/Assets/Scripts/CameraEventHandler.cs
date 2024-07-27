using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.SceneManagement;

public class CameraEventHandler : MonoBehaviour
{
    public XRNode inputSource;
    public UnityEngine.XR.Interaction.Toolkit.InputHelpers.Button inputButton;
    public float inputThreshold;
    public GameObject captureFlash;
    public GameObject lightFlash;
private void Update()
{
    List<InputDevice> devices = new List<InputDevice>();
    InputDevices.GetDevicesAtXRNode(inputSource, devices);

    foreach (var device in devices)
    {
        UnityEngine.XR.Interaction.Toolkit.InputHelpers.IsPressed(device, inputButton, out bool isPressed, inputThreshold);
        if (isPressed)
        {
            StartCoroutine(Capture());
        }
    }
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