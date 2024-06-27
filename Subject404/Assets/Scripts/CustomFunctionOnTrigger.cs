using System;
using UnityEngine;

public class CustomFunctionOnTrigger : MonoBehaviour
{
    public GameObject objectAssociated;
    public string componentType;
    public string methodName;
    private Component _componentInstance;
    private bool _isEnabled = false;

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
            var _method = _componentInstance.GetType().GetMethod(methodName);
            if (_method != null)
            {
                _method.Invoke(_componentInstance, null);
                _isEnabled = true;
            }
            else
            {
                Debug.LogError("Method not found: " + methodName);
            }
        }
    }
}
