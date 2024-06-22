using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableGameObjectOnTrigger : MonoBehaviour
{
    public GameObject objectToEnable;
    private bool isEnabled = false;
    void OnTriggerEnter()
    {
        if (objectToEnable != null)
        {
            if (!isEnabled)
            {
                objectToEnable.SetActive(true);
                isEnabled = true;
            }
        }
        else
        {
            Debug.LogError("Object to enable not set");
        }
    }
}
