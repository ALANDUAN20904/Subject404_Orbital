using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableGameObjectOnTrigger : MonoBehaviour
{
    private bool _isEnabled = false;
    public GameObject objectToEnable;
    public void OnTriggerEnter(Collider other)
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
