using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableGameObjectOnTrigger : MonoBehaviour
{
    public GameObject objectToEnable;
    private bool isEnabled = false;
    void OnTriggerEnter(){
        if (!isEnabled){
            objectToEnable.SetActive(true);
            isEnabled = true;
        }
    }
}
