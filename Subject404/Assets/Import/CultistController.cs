using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CultistController : MonoBehaviour
{
    public enum CultistState
    {
        Patrolling,
        Chasing,
        Caught
    }

    [SerializeField] private float walkSpeed = 2.0f;
    [SerializeField] private float runSpeed = 6.0f;
    [SerializeField] private float detectionRadius = 30f;
    [SerializeField] private float minDistanceToTarget = 0.1f;
    [SerializeField] private Transform teleportTarget;
    [SerializeField] private Camera playerCamera;

    private Vector3 target;
    private GameObject player;
    private float stateTimer = 0f;
    private float targetChangeInterval = 1f;
    private Animator animator;
    private CultistState currentState = CultistState.Patrolling;

    private const string ANIM_ORC_WALK = "Orc Walk";
    private const string ANIM_FAST_RUN = "Fast Run";

    private bool isPlayerCaught = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        SetNewRandomTarget();
        animator = GetComponent<Animator>();
        animator.Play(ANIM_ORC_WALK);
    }

    void Update()
    {
        stateTimer += Time.deltaTime;

        switch (currentState)
        {
            case CultistState.Patrolling:
                UpdatePatrollingState();
                break;
            case CultistState.Chasing:
                UpdateChasingState();
                break;
            case CultistState.Caught:
                UpdateCaughtState();
                break;
        }
    }

    void UpdatePatrollingState()
    {
        animator.Play(ANIM_ORC_WALK);

        if (player != null && IsPlayerInRange())
        {
            TransitionToState(CultistState.Chasing);
        }
        else if (stateTimer >= targetChangeInterval)
        {
            SetNewRandomTarget();
            stateTimer = 0f;
        }

        MoveTowardsTarget(walkSpeed);
    }

    void UpdateChasingState()
    {
        animator.Play(ANIM_FAST_RUN);

        if (player != null && IsPlayerInRange())
        {
            target = player.transform.position;
            MoveTowardsTarget(runSpeed);
            Debug.Log("Player is spotted");
        }
        else
        {
            TransitionToState(CultistState.Patrolling);
        }
    }

    void UpdateCaughtState()
    {
        if (teleportTarget != null)
        {

            Vector3 cameraForward = playerCamera.transform.forward;
            cameraForward.y = 0; // Flatten the vector to ignore vertical tilt
            cameraForward = cameraForward.normalized;

            // Calculate new position
            Vector3 newPosition = playerCamera.transform.position + (cameraForward * 0.7f);
            newPosition.y = transform.position.y; 
            
            transform.position = newPosition;

            transform.LookAt(new Vector3(playerCamera.transform.position.x, transform.position.y, playerCamera.transform.position.z));

            animator.speed = 0;
            Debug.Log("cultist transformed");
            isPlayerCaught = true;  
        }
        
    }

    void TransitionToState(CultistState newState)
    {
        currentState = newState;
        stateTimer = 0f;

        switch (newState)
        {
            case CultistState.Patrolling:
                SetNewRandomTarget();
                break;
            case CultistState.Chasing:
                // Setup for chasing state if needed
                break;
            case CultistState.Caught:
                // Setup for caught state if needed
                break;
        }
    }

    bool IsPlayerInRange()
    {
        return Vector3.Distance(transform.position, player.transform.position) <= detectionRadius;
    }

    void MoveTowardsTarget(float speed)
    {
        if (Vector3.Distance(transform.position, target) > minDistanceToTarget)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, step);
            transform.LookAt(target);
        }
    }

    void SetNewRandomTarget()
    {
        float randomX = Random.Range(-3f, 3f);
        float randomZ = Random.Range(-3f, 3f);
        target = transform.position + new Vector3(randomX, 0, randomZ);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TransitionToState(CultistState.Caught);
        }
    }

    void OnDrawGizmosSelected()
    {
        //update detection method Gizmos
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
