using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CultistController : MonoBehaviour
{
    //speed variable controlls NPC's speed when walking and running
    [SerializeField] private float walkSpeed = 2.0f;
    [SerializeField] private float runSpeed = 6.0f;

    //detectionRadius variable defines the radius within which the cultist can detect the player
    [SerializeField] private float detectionRadius = 10f;
    [SerializeField] private float minDistanceToTarget = 0.1f;

    private Vector3 target;
    private GameObject player;
    private float timeSinceLastTargetChange = 0f;
    private float targetChangeInterval = 3f;
    private bool _isPlayerCaught = false;
    private Animator animator;


    private const string ANIM_ORC_WALK = "Orc Walk";
    private const string ANIM_FAST_RUN = "Fast Run";

    bool IsPlayerInRange()
    {
        return Vector3.Distance(transform.position, player.transform.position) <= detectionRadius;
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        SetNewRandomTarget();

        animator = GetComponent<Animator>();
        animator.Play(ANIM_ORC_WALK);
    }

    void Update()
    {
        if (!_isPlayerCaught)
        {

            if (player != null && IsPlayerInRange())
            {
                target = player.transform.position;
                animator.Play(ANIM_FAST_RUN);   
            }
            else
            {
                //if target is not found within 3s, random movement triggered
                timeSinceLastTargetChange += Time.deltaTime;
                if (timeSinceLastTargetChange >= targetChangeInterval)
                {
                    SetNewRandomTarget();
                    timeSinceLastTargetChange = 0f;
                }

                animator.Play(ANIM_ORC_WALK);
            }
            MoveTowardsTarget();
        }
        
    }

    public void SetPlayerCaught()
    {
        _isPlayerCaught = true;
    }

    void MoveTowardsTarget()
    {
        if (Vector3.Distance(transform.position, target) > minDistanceToTarget)
        {
            // Determine the current speed based on the animation state
            float currentSpeed;
            if (animator.GetCurrentAnimatorStateInfo(0).IsName(ANIM_FAST_RUN))
            {
                currentSpeed = runSpeed;
            }
            else
            {
                currentSpeed = walkSpeed;
            }
            float step = currentSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, step);
            transform.LookAt(target);
        }
    }

    void SetNewRandomTarget()
    {
        float randomX = Random.Range(-10f, 10f);
        float randomZ = Random.Range(-10f, 10f);
        target = transform.position + new Vector3(randomX, 0, randomZ);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HandlePlayerCollision();
        }
    }

    private void HandlePlayerCollision()
    {
        _isPlayerCaught = true;
        Debug.Log("Player caught by cultist!");
        
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }

}
