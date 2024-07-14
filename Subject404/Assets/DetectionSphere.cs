using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZone : MonoBehaviour
{

    public static bool isPlayerInSafeZone = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInSafeZone = true;
            Debug.Log("Player entered safe zone");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInSafeZone = false;
            Debug.Log("Player exited safe zone");
        }
    }
}



