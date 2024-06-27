using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableGameObjectOnTrigger : MonoBehaviour
{
    public GameObject objectToEnable;
    private bool _isEnabled = false;
    void OnTriggerEnter()
    {
        if (objectToEnable != null)
        {
            if (!_isEnabled)
            {
                objectToEnable.SetActive(true);
                _isEnabled = true;
            }
        }
        else
        {
            Debug.LogError("Object to enable not set");
        }
    }
}
