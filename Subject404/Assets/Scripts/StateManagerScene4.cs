using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManagerScene4 : MonoBehaviour
{
    public GameObject Axe;
    public GameObject AxeSymbol;
    private ToggleInteraction toggleAxe;
    private bool collided = false;
    private bool viewedEnemy = false;
    public GameObject Enemy;
    public GameObject EnemyCollider;
    public Camera mainCamera;
    private Raycast raycaster;

    void Start(){
        raycaster = mainCamera.GetComponent<Raycast>();
    }
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
    
       if (!viewedEnemy && raycaster.IsObjectInView(EnemyCollider))
        {
            DisableEnemy();
        }
    }

    void DisableEnemy(){
        StartCoroutine(DisableEnemyAfterDelay());
    }
    private IEnumerator DisableEnemyAfterDelay(){
        yield return new WaitForSeconds(1);
        Enemy.SetActive(false);
        viewedEnemy = true;
    }
}
