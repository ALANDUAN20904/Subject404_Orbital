using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomFunctionOnTrigger : MonoBehaviour
{
    public GameObject objectAssociated;
    public string componentType;
    public string methodName;
    private Component componentInstance;
    private bool isEnabled = false;

    void Awake()
    {
        if (objectAssociated != null && !string.IsNullOrEmpty(componentType))
        {
            Type type = Type.GetType(componentType);
            if (type != null)
            {
                componentInstance = objectAssociated.GetComponent(type);
            }
            else
            {
                Debug.LogError("Component type not found: " + componentType);
            }
        }
        else
        {
            Debug.LogError("objectAssociated or componentType is null/empty");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!isEnabled && componentInstance != null && !string.IsNullOrEmpty(methodName))
        {
            var method = componentInstance.GetType().GetMethod(methodName);
            if (method != null)
            {
                method.Invoke(componentInstance, null);
                isEnabled = true;
            }
            else
            {
                Debug.LogError("Method not found: " + methodName);
            }
        }
    }
}
