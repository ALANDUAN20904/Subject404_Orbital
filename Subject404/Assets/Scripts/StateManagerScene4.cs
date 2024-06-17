using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManagerScene4 : MonoBehaviour
{
    public GameObject Axe;
    private bool collided = false;

    public void setCollided(){
        collided = true;
    }
    void StartAxeMotion()
    {
        Axe.SetActive(true);
    }

    void Update()
    {
        if (collided && !Axe.activeSelf){
            StartAxeMotion();
        }
    }
}
