using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickToGoTest : MonoBehaviour
{
    NavMeshAgent _agent;


    // Start is called before the first frame update
    void Start() => _agent = GetComponent<NavMeshAgent>();

    

    // Update is called once per frame
    void Update()
    {
     if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray,out var hitInfo)) 
            { 
                Vector3 randomOffset  = Random.insideUnitSphere * 0.5f;
                randomOffset.y = 0;
                _agent.destination = hitInfo.point + randomOffset;
            }
        }   
    }
}
