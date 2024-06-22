using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ToggleInteraction : MonoBehaviour
{
    public XRGrabInteractable xRGrabInteractable;
    public void EnableObjectInteraction()
    {
        xRGrabInteractable.enabled = true;
    }
    public void DisableObjectInteraction()
    {
        xRGrabInteractable.enabled = false;
    }
    public void ToggleObjectInteraction()
    {
        xRGrabInteractable.enabled = !xRGrabInteractable.enabled;
    }
}
