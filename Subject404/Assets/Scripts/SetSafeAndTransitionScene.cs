using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetSafeAndTransitionScene : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Reached");
        if (MainManager.Instance != null)
        {
            MainManager.Instance.SetSafe();
        }
        SceneManager.LoadScene(9);
    }
}
