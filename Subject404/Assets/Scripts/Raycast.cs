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
            Ray ray = new Ray(transform.position, transform.forward);
            Vector3 vec = target.transform.position - transform.position;
            RaycastHit raycastHit;
            if (Physics.Raycast(ray, out raycastHit, layerMask))
            {
                Vector3 vec2 = raycastHit.point - transform.position;
                return !hasObstacle(target) && Vector3.Angle(vec2, vec) < 45.0f;
            }
            return false;
        }
        Debug.LogError("Raycast target not provided");
        return false;
    }

    private bool hasObstacle(GameObject target)
    {
        Ray obstacleCheckRay = new Ray(transform.position, target.transform.position - transform.position);
        RaycastHit obstacleHit;
        if (Physics.Raycast(obstacleCheckRay, out obstacleHit, layerMask))
        {
            return obstacleHit.collider.gameObject.name != target.name;
        }
        return true;
    }
}
