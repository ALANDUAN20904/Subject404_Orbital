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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Create local variable TriggerValue for "pinch"
        float TriggerValue = pinchAnimationAction.action.ReadValue<float>();

        // Check our input
        // Debug.Log(TriggerValue);

        handAnimator.SetFloat("Trigger", TriggerValue);

        // Create local variable TriggerValue for "grip"
        float GripValue = gripAnimationAction.action.ReadValue<float>();

        handAnimator.SetFloat("Grip", GripValue);

    }
}
