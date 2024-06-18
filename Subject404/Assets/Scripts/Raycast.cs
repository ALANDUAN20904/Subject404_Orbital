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
            return raycastHit.collider.gameObject == target;
        }
        return false;
    }
}
