using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomFunctionOnTriggerScene7 : MonoBehaviour
{
    
    void OnTriggerEnter()
    {
        if (MainManager.Instance != null)
        {
            MainManager.Instance.SetSafe();
            SceneManager.LoadScene(9);
        }
    }
}
