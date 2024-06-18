using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManagerScene4 : MonoBehaviour
{
    public GameObject Axe;
    public GameObject AxeSymbol;
    private ToggleInteraction toggleAxe;
    private bool collided = false;

    public void enableAxeInteraction(){
        toggleAxe = Axe.GetComponent<ToggleInteraction>();
        toggleAxe.EnableObjectInteraction();
    }
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
            AxeSymbol.SetActive(true);
        }
    }
}
