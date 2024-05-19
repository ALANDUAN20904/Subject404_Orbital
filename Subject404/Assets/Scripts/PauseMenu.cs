using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public InputActionReference openMenuAction;

    private void Awake() {
        openMenuAction.action.Enable();
        openMenuAction.action.performed += ToggleMenu;
        InputSystem.onDeviceChange += OnDeviceChange;
    }
    private void OnDestroy() {
        openMenuAction.action.Disable();
        openMenuAction.action.performed -= ToggleMenu;
        InputSystem.onDeviceChange -= OnDeviceChange;
    }
    private void ToggleMenu(InputAction.CallbackContext context) {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
    }
    private void OnDeviceChange(InputDevice device, InputDeviceChange change) {
        switch(change) {
            case InputDeviceChange.Disconnected:
                openMenuAction.action.Disable();
                openMenuAction.action.performed -= ToggleMenu;
                break;
            case InputDeviceChange.Reconnected:
                openMenuAction.action.Enable();
                openMenuAction.action.performed += ToggleMenu;
                break;
        }
    }
}
