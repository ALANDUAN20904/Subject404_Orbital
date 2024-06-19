using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManagerScene4 : MonoBehaviour
{
    private int sceneState;
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
    private TextUpdater textUpdater;
    string[] instructions = {"Walk to the store", "Look behind", "Walk to the store", "Grab to inspect the axe", "Walk to the store"};
    private void Awake(){
        textUpdater = GetComponent<TextUpdater>();
        sceneState = 0;
    }
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
        sceneState = 1;
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
        string text = instructions[sceneState];
        textUpdater.UpdateText(ref text);

        if (collided && !Axe.activeSelf){
            StartAxeMotion();
            AxeSymbol.SetActive(true);
            sceneState = 3;
        }
    
       if (!viewedEnemy && raycaster.IsObjectInView(EnemyCollider))
        {
            DisableEnemy();
            gameSound.SetActive(true);
            heartBeat.SetActive(true);
            sceneState = 2;
        }
    }
    public int getSceneState(){
        return sceneState;
    }
    public void setSceneState(int state){
        sceneState = state;
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
