using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiAgent : MonoBehaviour
{
    public AiStateMachine stateMachine;
    public AiStateId initialState;
    [HideInInspector]public NavMeshAgent navMeshAgent;
    private Animator animator;

    public float patrolSpeed = 0.5f;
    public float chaseSpeed = 1.0f;

    public SafeZone safeZone;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        animator = GetComponent<Animator>();
        
        stateMachine = new AiStateMachine(this);
        stateMachine.RegisterState(new AiChasePlayerState());
        stateMachine.RegisterState(new AiPatrolState());
        stateMachine.ChangeState(initialState);
        
    }

    // Update is called once per frame
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
        if (SafeZone.isPlayerInSafeZone)
        {
            return false;
        }
        
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
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
            }
        }
        return false;
    }
}
