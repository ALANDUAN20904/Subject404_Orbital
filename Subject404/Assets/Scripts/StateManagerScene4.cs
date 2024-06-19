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
    public GameObject Bulb;
    private BulbAudio bulbAudioPlayer;
    public GameObject gameSound;
    public GameObject heartBeat;
    public GameObject enemyFootsteps;
    public GameObject Mirror;
    public GameObject ParkEnemy;
    public Camera mainCamera;
    private Raycast raycaster;

    void Start(){
        raycaster = mainCamera.GetComponent<Raycast>();
        bulbAudioPlayer = Bulb.GetComponent<BulbAudio>();
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
    public void enableEnemy(){
        enemyFootsteps.SetActive(false);
        Enemy.SetActive(true);
        bulbAudioPlayer.playSparkAudio();
    }
    public void activateMirror(){
        Mirror.SetActive(true);
        Rigidbody rb = Mirror.GetComponent<Rigidbody>();
        rb.AddForce(0,-10,0);
    }
    public void activateParkEnemy(){
        ParkEnemy.SetActive(true);
    }
    public void disableParkEnemy(){
        ParkEnemy.SetActive(false);
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
            gameSound.SetActive(true);
            heartBeat.SetActive(true);
        }
    }

    void DisableEnemy(){
        StartCoroutine(DisableEnemyAfterDelay());
    }
    private IEnumerator DisableEnemyAfterDelay(){
        yield return StartCoroutine(bulbAudioPlayer.playExplosion());
        Enemy.SetActive(false);
        viewedEnemy = true;
    }
}
