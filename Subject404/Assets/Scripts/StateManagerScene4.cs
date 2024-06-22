using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class StateManagerScene4 : MonoBehaviour
{
    private int sceneState;
    public GameObject Axe;
    public GameObject AxeSymbol;
    private ToggleInteraction toggleAxe;
    private bool collided = false;
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

    string[] instructions = { "Walk to the store", "Look behind", "Walk to the store", "Grab to inspect the axe", "Walk to the store" };
    private void Awake()
    {
        textUpdater = GetComponent<TextUpdater>();
        if (textUpdater == null)
        {
            Debug.LogError("Text Updater component not found");
        }
        sceneState = 0;
    }
    void Start()
    {
        if (mainCamera != null)
        {
            raycaster = mainCamera.GetComponent<Raycast>();
            if (raycaster == null)
            {
                Debug.LogWarning("Raycaster component not found on attached camera, creating new raycaster");
                raycaster = mainCamera.gameObject.AddComponent<Raycast>();
            }
        }
        else
        {
            Debug.LogError("Main Camera not set");
        }
        if (Bulb != null)
        {
            bulbAudioPlayer = Bulb.GetComponent<BulbAudio>();
            if (bulbAudioPlayer == null)
            {
                Debug.LogError("Bulb Audio component not found");
            }
        }
        else
        {
            Debug.LogError("Bulb GameObject not set");
        }
    }
    public void EnableAxeInteraction()
    {
        if (Axe != null)
        {
            toggleAxe = Axe.GetComponent<ToggleInteraction>();
            if (toggleAxe == null)
            {
                Debug.LogWarning("ToggleInteraction component not found, creating new");
                toggleAxe = Axe.AddComponent<ToggleInteraction>();
                toggleAxe.xRGrabInteractable = Axe.GetComponent<XRGrabInteractable>();
            }
            toggleAxe.EnableObjectInteraction();
        }
        else
        {
            Debug.LogError("Axe GameObject not set");
        }
    }
    public void SetCollided()
    {
        collided = true;
    }
    void StartAxeMotion()
    {
        if (Axe != null)
        {
            Axe.SetActive(true);
        }
        else
        {
            Debug.LogError("Axe GameObjet not set");
        }
    }
    public void EnableEnemy()
    {
        if (enemyFootsteps != null && Enemy != null && bulbAudioPlayer != null)
        {
            enemyFootsteps.SetActive(false);
            Enemy.SetActive(true);
            bulbAudioPlayer.PlaySparkAudio();
            sceneState = 1;
        }
        else
        {
            Debug.LogError("One or more parameters missing");
        }
    }
    public void ActivateMirror()
    {
        if (Mirror != null)
        {
            Mirror.SetActive(true);
            Rigidbody rb = Mirror.GetComponent<Rigidbody>();
            if (rb == null)
            {
                Debug.LogWarning("Rigidbody component not found on Mirror GameObject, creating new");
                rb = Mirror.AddComponent<Rigidbody>();
                rb.useGravity = true;
            }
            rb.AddForce(0, -10, 0);
        }
        else
        {
            Debug.LogError("Mirror GameObject not set");
        }
    }
    public void ActivateParkEnemy()
    {
        if (ParkEnemy != null)
        {
            ParkEnemy.SetActive(true);
        }
        else
        {
            Debug.LogError("ParkEnemy GameObject not set");
        }
    }
    public void DisableParkEnemy()
    {
        if (ParkEnemy != null)
        {
            ParkEnemy.SetActive(false);
        }
        else
        {
            Debug.LogError("ParkEnemy GameObject not set");
        }
    }
    void Update()
    {
        string text = instructions[sceneState];
        textUpdater.UpdateText(ref text);

        if (Axe != null)
        {
            if (collided && !Axe.activeSelf)
            {
                StartAxeMotion();
                AxeSymbol.SetActive(true);
                sceneState = 3;
            }
        }
        else
        {
            Debug.LogError("Axe GameObject not set");
        }

        if (Enemy.activeSelf && raycaster.IsObjectInView(EnemyCollider))
        {
            DisableEnemy();
            if (gameSound != null && heartBeat != null)
            {
                gameSound.SetActive(true);
                heartBeat.SetActive(true);
                sceneState = 2;
            }
            else
            {
                Debug.LogError("One or more parameters missing");
            }
        }
    }
    public int GetSceneState()
    {
        return sceneState;
    }
    public void SetSceneState(int state)
    {
        sceneState = state;
    }
    void DisableEnemy()
    {
        StartCoroutine(DisableEnemyAfterDelay());
    }
    private IEnumerator DisableEnemyAfterDelay()
    {
        yield return StartCoroutine(bulbAudioPlayer.PlayExplosion());
        if (Enemy != null)
        {
            Enemy.SetActive(false);
        }
        else
        {
            Debug.LogError("Enemy GameObject not set");
        }
    }
}
