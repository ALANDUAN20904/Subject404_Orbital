using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public Transform player, destination;
    public CharacterController playerObject;

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerObject.enabled = false;
            player.position = destination.position;
            playerObject.enabled = true;
            Physics.SyncTransforms();
        }
    }
}
