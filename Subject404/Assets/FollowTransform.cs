using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class FollowTransform : MonoBehaviour
{
    /*
    [SerializeField] private Transform lookAt;
    [SerializeField] private Transform transformToFollow;
    

    private Transform _thisTransform;
    */

   /* private void Start()
    {
        _thisTransform = transform;
    }
   */
    private void Update()
    {
        /*_thisTransform.LookAt(lookAt, Vector3.up);
        _thisTransform.Rotate(xAngle: 0f, yAngle: 180f, zAngle: 0f);
        Vector3 newPosition  = _thisTransform.position;
        Vector3 followPosition  = transformToFollow.position;
        transform.position = newPosition;
        */

        gameObject.transform.rotation = Camera.main.transform.rotation;
        gameObject.transform.position = Camera.main.transform.position;

    }
}
