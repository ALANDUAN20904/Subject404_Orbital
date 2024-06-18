using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    Ray ray;
    RaycastHit raycastHit;

    public bool IsObjectInView(GameObject target)
    {
        ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out raycastHit)){
            Debug.Log(raycastHit.collider.gameObject.name);
            Debug.Log(raycastHit.collider.gameObject == target);
            return raycastHit.collider.gameObject == target;
        }
        return false;
    }
}
