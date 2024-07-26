using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class CameraEventHandler : MonoBehaviour
{

private void Update()
{
    List<InputDevice> _device = new List<InputDevice>();
    InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.Controller, _device);
    Debug.Log(_device.Count);
}
}