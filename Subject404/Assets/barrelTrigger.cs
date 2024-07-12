using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrelTrigger : MonoBehaviour
{

    //public Transform barrelCenter;

    public GameObject barrel;
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TeleportPlayer(other.gameObject);
        }
    }

    private void TeleportPlayer(GameObject player)
    {
        if (barrel != null)
        {
            Renderer barrelRenderer = barrel.GetComponent<Renderer>();
            if (barrelRenderer != null)
            {
                Vector3 barrelCenter = barrelRenderer.bounds.center;
                Vector3 teleportPosition = barrelCenter ;

                // Debug information
                Debug.Log($"Barrel Center: {barrelCenter}");
                Debug.Log($"Teleport Position: {teleportPosition}");

                player.transform.position = teleportPosition;
                Debug.Log($"Player Position After Teleport: {player.transform.position}");
            }
            else
            {
                Debug.LogWarning("Barrel doesn't have a Renderer component!");
            }
        }
        else
        {
            Debug.LogWarning("Barrel center not assigned!");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
