using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiAgent : MonoBehaviour
{
    //different access modifier for distinct classes with different purposes
    public AiStateMachine stateMachine;
    public AiStateId initialState;
    private Animator animator;
    public float patrolSpeed = 0.5f;
    public float chaseSpeed = 1.0f;
    public SafeZone safeZone;
    [HideInInspector] public NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        animator = GetComponent<Animator>();
        
        //place to add new states 
        stateMachine = new AiStateMachine(this);
        stateMachine.RegisterState(new AiChasePlayerState());
        stateMachine.RegisterState(new AiPatrolState());
        stateMachine.RegisterState(new AiCaughtState());
        stateMachine.ChangeState(initialState);
        
    }

    void Update()
    {
        if (stateMachine != null)
        {
            stateMachine.Update();
        }
        
    }

    public void SetAnimationSpeed(float speed)
    {
        if (animator != null) 
        { 
            animator.SetFloat("Speed", speed);
        }
    }

    public bool IsPlayerDetected(float detectionRadius, float detectionAngle)
    {
        //check if the player is inside the SafeZone
        if (SafeZone.isPlayerInSafeZone)
        {
            return false;
        }
        
        //collect every collider inside cultist's sphere
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                //normalise the distance between the cultist's and the player's position
                Vector3 directionToPlayer = (collider.transform.position - transform.position).normalized;
                float angle = Vector3.Angle(transform.forward, directionToPlayer);
                if (angle < detectionAngle * 0.5f)
                {
                    // Check if there's no collider between the agent and the player
                    RaycastHit hit;
                    if (!Physics.Raycast(transform.position, directionToPlayer, out hit, detectionRadius) || hit.collider.CompareTag("Player"))
                    {
                        return true;
                    }
                }
                Debug.Log("detected");
            }
        }
        return false;
    }

    //switch to Caught state with collider check
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            stateMachine.ChangeState(AiStateId.Caught);
        }
    }
}
