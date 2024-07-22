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

                //adjust teleportation y-axis
                float yOffset = barrelRenderer.bounds.extents.y;

                Vector3 teleportPosition = new Vector3(barrelCenter.x,barrelCenter.y-yOffset,barrelCenter.z);

                //teleportation{osition.y += 0.1f; //small upwards offset, just in case player is stuck in the ground
                player.transform.position = teleportPosition;
                

                // Start the coroutine for the second teleport
                StartCoroutine(SecondTeleport(player, teleportPosition));
            }
        }   
    }
}
