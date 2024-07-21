using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//detection is implemented in the patrol state

public class AiPatrolState : AiState

{
    public float patrolRadius = 10.0f;
    public float detectionRadius = 30.0f;
    public float detectionAngle = 90.0f;
    private Vector3 patrolTarget;
    private float stateTimer = 0f;
    private float targetChangeInterval = 5.0f;


    public AiStateId GetId()
    {
        return AiStateId.Patrol;
    }

    public void Enter(AiAgent agent)
    {
        SetNewRandomTarget(agent);
        // Set patrol animation
        Animator animator = agent.GetComponent<Animator>();
        if (animator != null)
        {
            animator.Play("Orc Walk"); // Make sure this animation exists
        }
    }
    public void Update(AiAgent agent)
    {
        stateTimer += Time.deltaTime;

        if (IsPlayerDetected(agent))
        {
            agent.stateMachine.ChangeState(AiStateId.chasePlayer);
            return;
        }

        if (stateTimer >= targetChangeInterval || agent.navMeshAgent.remainingDistance < 0.1f)
        {
            SetNewRandomTarget(agent);
            stateTimer = 0f;
        }

        // Move towards patrol target
        agent.navMeshAgent.SetDestination(patrolTarget);

    }
    public void Exit(AiAgent agent)
    {

    }

    private void SetNewRandomTarget(AiAgent agent)
    {
        Vector3 randomDirection = Random.insideUnitSphere * patrolRadius;
        randomDirection += agent.transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, patrolRadius, 1);
        patrolTarget = hit.position;
    }


    private bool IsPlayerDetected(AiAgent agent)
    {
        Collider[] colliders = Physics.OverlapSphere(agent.transform.position, detectionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                Vector3 directionToPlayer = (collider.transform.position - agent.transform.position).normalized;
                float angle = Vector3.Angle(agent.transform.forward, directionToPlayer);
                if (angle < detectionAngle * 0.5f)
                {
                    // Check if there's no obstacle between the agent and the player
                    RaycastHit hit;
                    if (!Physics.Raycast(agent.transform.position, directionToPlayer, out hit, detectionRadius) || hit.collider.CompareTag("Player"))
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
}
