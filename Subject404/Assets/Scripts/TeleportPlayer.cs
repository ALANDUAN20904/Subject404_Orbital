using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public Transform player, destination;
    public CharacterController playerObject;
    public GameObject gameInstructions;
    private StateManagerScene6 _stateManager;

    void Start()
    {
        _stateManager = gameInstructions.GetComponent<StateManagerScene6>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerObject.enabled = false;
            player.position = destination.position;
            playerObject.enabled = true;
            Physics.SyncTransforms();
            _stateManager.SetSceneState(2);
        }
    }
}
