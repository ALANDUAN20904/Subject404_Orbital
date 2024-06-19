using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateScream : MonoBehaviour
{
    public GameObject screamSource;
    void OnTriggerEnter(){
        screamSource.SetActive(true);
    }
}
