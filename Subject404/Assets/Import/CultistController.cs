using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CultistController : MonoBehaviour
{
    //speed variable controlls NPC's speed
    [SerializeField] private float speed = 2.0f;

    //detectionRadius variable defines the radius within which the cultist can detect the player
    [SerializeField] private float detectionRadius = 10f;
    [SerializeField] private float minDistanceToTarget = 0.1f;

    private Vector3 target;
    private GameObject player;
    private float timeSinceLastTargetChange = 0f;
    private float targetChangeInterval = 3f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        SetNewRandomTarget();
    }

    void Update()
    {
        if (player != null && IsPlayerInRange())
        {
            target = player.transform.position;
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
        }

        MoveTowardsTarget();
    }

    void MoveTowardsTarget()
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
        float randomX = Random.Range(-10f, 10f);
        float randomZ = Random.Range(-10f, 10f);
        target = transform.position + new Vector3(randomX, 0, randomZ);
    }

    bool IsPlayerInRange()
    {
        return Vector3.Distance(transform.position, player.transform.position) <= detectionRadius;
    }

    
}
