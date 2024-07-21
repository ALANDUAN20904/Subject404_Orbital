using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class AiLocalmotion : MonoBehaviour
{
   
    NavMeshAgent agent;
    Animator animator;
    

    public Transform PlayerTransform;

    
    void Start()
    {
        if (PlayerTransform == null)
        {
            PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator> ();
    }

    
    void Update()
    {



        if (agent.hasPath)
        {
            animator.SetFloat("Speed", agent.velocity.magnitude);
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }
        

    }

    void OnDrawGizmos()
    {
        
    }
}
