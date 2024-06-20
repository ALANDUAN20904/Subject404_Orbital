using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class FollowTransform : MonoBehaviour
{
    private void Update()
    {
        gameObject.transform.rotation = Camera.main.transform.rotation;
        gameObject.transform.position = Camera.main.transform.position;

    }
}
