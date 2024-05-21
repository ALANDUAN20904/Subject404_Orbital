using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public InputActionReference openMenuAction;
    public GameObject LeftLaser;

    private void Awake() {
        openMenuAction.action.Enable();
        LeftLaser.SetActive(false);
        openMenuAction.action.performed += ToggleMenu;
        InputSystem.onDeviceChange += OnDeviceChange;
    }
    private void OnDestroy() {
        openMenuAction.action.Disable();
      
        openMenuAction.action.performed -= ToggleMenu;
        InputSystem.onDeviceChange -= OnDeviceChange;
    }
    private void ToggleMenu(InputAction.CallbackContext context) {
        bool isActive = pauseMenu.activeSelf;
        bool LaserActive = LeftLaser.activeSelf;
        Debug.Log(LaserActive);
        pauseMenu.SetActive(!isActive);
        LeftLaser.SetActive(!LaserActive);
        Time.timeScale = isActive ? 1f : 0f;
       
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

    public void Resume()
    {
        Time.timeScale = 1f;
    }
}
