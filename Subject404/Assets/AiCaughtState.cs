using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiCaughtState : AiState
{
    private Camera playerCamera;
    

    public AiStateId GetId()
    {
        return AiStateId.Caught;
    }

    public void Enter(AiAgent agent)
    {
        if (playerCamera == null)
        {
            playerCamera = Camera.main; // Assuming the main camera is the player's camera
        }

        UpdatePosition(agent);

        Animator agentAnimator = agent.GetComponent<Animator>();
        if(agentAnimator != null)
        {
            agentAnimator.speed = 0;
        }
        
        Debug.Log("cultist transformed");
    }

    public void Update(AiAgent agent)
    {
        UpdatePosition(agent);
        Debug.Log("cultist at caught state");
    }

    public void Exit(AiAgent agent)
    {

    }

    private void UpdatePosition(AiAgent agent)
    {
        Vector3 cameraForward = playerCamera.transform.forward;
        cameraForward.y = 0; // Flatten the vector to ignore vertical tilt
        cameraForward = cameraForward.normalized;

        // Calculate new position
        Vector3 newPosition = playerCamera.transform.position + (cameraForward * 0.7f);
        newPosition.y = agent.transform.position.y;

        agent.transform.position = newPosition;

        agent.transform.LookAt(new Vector3(playerCamera.transform.position.x, agent.transform.position.y, playerCamera.transform.position.z));
    }






}
