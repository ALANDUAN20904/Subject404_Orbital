using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrelTrigger : MonoBehaviour
{

    //public Transform barrelCenter;

    public GameObject barrel;
    public float delay = 5.0f;
    public Vector3 teleportationOffset = new Vector3(1.0f, 0, 0);
    


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

    private IEnumerator SecondTeleport(GameObject player, Vector3 teleportPosition)
    {
        Vector3 NewteleportPosition = teleportPosition + teleportationOffset;
        yield return new WaitForSeconds(delay);
        player.transform.position = NewteleportPosition;
        
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

                // Start the coroutine for the second teleport
                StartCoroutine(SecondTeleport(player, teleportPosition));
            }
            else
            {
                Debug.LogWarning("Barrel doesn't have a Renderer component");
            }
        }
        else
        {
            Debug.LogWarning("Barrel center not assigned!");
        }
    }
    
    






}
