using System;
using UnityEngine;

public class CustomFunctionOnTrigger : MonoBehaviour
{
    private Component _componentInstance;
    private bool _isEnabled = false;
    public GameObject objectAssociated;
    public string componentType;
    public string methodName;
    
    void Awake()
    {
        if (objectAssociated != null && !string.IsNullOrEmpty(componentType))
        {
            Type type = Type.GetType(componentType);
            if (type != null)
            {
                _componentInstance = objectAssociated.GetComponent(type);
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
        if (!_isEnabled && _componentInstance != null && !string.IsNullOrEmpty(methodName))
        {
            var method = _componentInstance.GetType().GetMethod(methodName);
            if (method != null)
            {
                method.Invoke(_componentInstance, null);
                _isEnabled = true;
            }
            else
            {
                Debug.LogError("Method not found: " + methodName);
            }
        }
    }
}
