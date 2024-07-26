using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetSafeAndTransitionScene : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (MainManager.Instance != null)
        {
            MainManager.Instance.SetSafe();
        }
        SceneManager.LoadScene(9);
    }
}
