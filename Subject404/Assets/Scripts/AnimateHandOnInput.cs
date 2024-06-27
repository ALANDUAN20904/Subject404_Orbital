using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class AnimateHandOnInput : MonoBehaviour
{

    // Create variable InputActionProperty 
    public InputActionProperty pinchAnimationAction;
    public InputActionProperty gripAnimationAction;
    public Animator handAnimator;

    void Update()
    {
        // Create local variable TriggerValue for "pinch"
        float _triggerValue = pinchAnimationAction.action.ReadValue<float>();

        // Check our input
        // Debug.Log(TriggerValue);

        handAnimator.SetFloat("Trigger", _triggerValue);

        // Create local variable TriggerValue for "grip"
        float _gripValue = gripAnimationAction.action.ReadValue<float>();

        handAnimator.SetFloat("Grip", _gripValue);

    }
}
