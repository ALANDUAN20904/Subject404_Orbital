using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//detection is implemented in the patrol state

public class AiPatrolState : AiState

{
    public float patrolRadius = 20.0f;
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
            animator.Play("Orc Walk"); 
        }
        agent.navMeshAgent.speed = agent.patrolSpeed;
        agent.SetAnimationSpeed(agent.patrolSpeed);
    }

    public void Update(AiAgent agent)
    {
        stateTimer += Time.deltaTime;

        if (agent.IsPlayerDetected(detectionRadius,detectionAngle))
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
        float currentSpeed = agent.navMeshAgent.speed;
        agent.SetAnimationSpeed(currentSpeed);
        Debug.Log("cultist at patrol state");
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
}
