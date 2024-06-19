using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    Ray ray;
    RaycastHit raycastHit;
    public LayerMask layerMask;

    public bool IsObjectInView(GameObject target)
    {
        ray = new Ray(transform.position, transform.forward);
        Vector3 vec = target.transform.position - transform.position;
        if (Physics.Raycast(ray, out raycastHit, layerMask)){
            Vector3 vec2 = raycastHit.point - transform.position;
            return Vector3.Angle(vec2, vec) < 45.0f;
        }
        return false;
    }
}
