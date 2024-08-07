using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AiChasePlayerState : AiState
{
    public Transform playerTransform;
    public float maxTime = 1.0f;
    public float maxDistance = 1.0f;
    float timer = 0.0f;
    public float detectionRadius = 30.0f;

    public AiStateId GetId()
    {
        return AiStateId.chasePlayer;
    }

    public void Enter(AiAgent agent)
    {
        if (playerTransform == null)
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }

        agent.navMeshAgent.speed = agent.chaseSpeed;
        agent.SetAnimationSpeed(agent.chaseSpeed);
    }

    public void Update(AiAgent agent)
    {
        if (!agent.enabled)
        {
            return;
        }
       
        if (!agent.navMeshAgent.hasPath)
        {
            agent.navMeshAgent.destination = playerTransform.position;
        }

        if (SafeZone.isPlayerInSafeZone)
        {
            agent.stateMachine.ChangeState(AiStateId.Patrol);
            return;
        }

        timer -= Time.deltaTime;
        if (timer < 0.0f)
        {
            Vector3 direction = (playerTransform.position - agent.navMeshAgent.destination);
            direction.y = 0;
            if (direction.sqrMagnitude > maxDistance * maxDistance)
            {
                if (agent.navMeshAgent.pathStatus != NavMeshPathStatus.PathPartial)
                {
                    agent.navMeshAgent.destination = playerTransform.position;
                }
            }
            timer = maxTime;
        }

        float currentSpeed = agent.navMeshAgent.speed;
        agent.SetAnimationSpeed(currentSpeed);
        Debug.Log("cultist at chase state");
    }
    public void Exit(AiAgent agent)
    {

    }
}