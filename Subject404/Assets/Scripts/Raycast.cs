using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public LayerMask layerMask;

    public bool IsObjectInView(GameObject target)
    {
        if (target != null)
        {
            Ray _ray = new Ray(transform.position, transform.forward);
            Vector3 _vec = target.transform.position - transform.position;
            RaycastHit _raycastHit;
            if (Physics.Raycast(_ray, out _raycastHit, layerMask))
            {
                Vector3 _vec2 = _raycastHit.point - transform.position;
                return !HasObstacle(target) && Vector3.Angle(_vec2, _vec) < 45.0f;
            }
            return false;
        }
        Debug.LogError("Raycast target not provided");
        return false;
    }

    private bool HasObstacle(GameObject target)
    {
        Ray _obstacleCheckRay = new Ray(transform.position, target.transform.position - transform.position);
        RaycastHit _obstacleHit;
        if (Physics.Raycast(_obstacleCheckRay, out _obstacleHit, layerMask))
        {
            return _obstacleHit.collider.gameObject.name != target.name;
        }
        return true;
    }
}
