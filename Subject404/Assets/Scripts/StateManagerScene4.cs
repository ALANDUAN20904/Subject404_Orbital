using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class StateManagerScene4 : MonoBehaviour
{
    private int _sceneState;
    private int _prevState = -1;
    private Raycast _raycaster;
    private TextUpdater _textUpdater;
    private ToggleInteraction _toggleAxe;
    private BulbAudio _bulbAudioPlayer;
    private bool _collided = false;
    private string[] _instructions = { "Walk to the store", "Look behind", "Walk to the store", "Grab to inspect the axe", "Walk to the store" };
    public GameObject Axe;
    public GameObject AxeSymbol;
    public GameObject Enemy;
    public GameObject EnemyCollider;
    public GameObject PlayerMotionBlock;
    public GameObject Bulb;
    public GameObject gameSound;
    public GameObject heartBeat;
    public GameObject enemyFootsteps;
    public GameObject Mirror;
    public GameObject ParkEnemy;
    public Camera mainCamera;
    private void Awake()
    {
        _textUpdater = GetComponent<TextUpdater>();
        if (_textUpdater == null)
        {
            Debug.LogError("Text Updater component not found");
        }
        _sceneState = 0;
    }
    void Start()
    {
        if (mainCamera != null)
        {
            _raycaster = mainCamera.GetComponent<Raycast>();
            if (_raycaster == null)
            {
                Debug.LogWarning("Raycaster component not found on attached camera, creating new raycaster");
                _raycaster = mainCamera.gameObject.AddComponent<Raycast>();
            }
        }
        else
        {
            Debug.LogError("Main Camera not set");
        }
        if (Bulb != null)
        {
            _bulbAudioPlayer = Bulb.GetComponent<BulbAudio>();
            if (_bulbAudioPlayer == null)
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
            _toggleAxe = Axe.GetComponent<ToggleInteraction>();
            if (_toggleAxe == null)
            {
                Debug.LogWarning("ToggleInteraction component not found, creating new");
                _toggleAxe = Axe.AddComponent<ToggleInteraction>();
                _toggleAxe.xRGrabInteractable = Axe.GetComponent<XRGrabInteractable>();
            }
            _toggleAxe.EnableObjectInteraction();
        }
        else
        {
            Debug.LogError("Axe GameObject not set");
        }
    }
    public void SetCollided()
    {
        _collided = true;
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
        if (enemyFootsteps != null && Enemy != null && _bulbAudioPlayer != null)
        {
            enemyFootsteps.SetActive(false);
            Enemy.SetActive(true);
            _bulbAudioPlayer.PlaySparkAudio();
            _sceneState = 1;
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
        if (_sceneState != _prevState)
        {
            string text = _instructions[_sceneState];
            _textUpdater.UpdateText(ref text);
            _prevState = _sceneState;
        }

        if (Axe != null)
        {
            if (_collided && !Axe.activeSelf)
            {
                StartAxeMotion();
                AxeSymbol.SetActive(true);
                _sceneState = 3;
            }
        }
        else
        {
            Debug.LogError("Axe GameObject not set");
        }

        if (Enemy.activeSelf && _raycaster.IsObjectInView(EnemyCollider))
        {
            DisableEnemy();
            if (gameSound != null && heartBeat != null)
            {
                gameSound.SetActive(true);
                heartBeat.SetActive(true);
                _sceneState = 2;
            }
            else
            {
                Debug.LogError("One or more parameters missing");
            }
        }
    }
    public int GetSceneState()
    {
        return _sceneState;
    }
    public void SetSceneState(int state)
    {
        _sceneState = state;
    }
    void DisableEnemy()
    {
        StartCoroutine(DisableEnemyAfterDelay());
    }
    private IEnumerator DisableEnemyAfterDelay()
    {
        yield return StartCoroutine(_bulbAudioPlayer.PlayExplosion());
        if (Enemy != null)
        {
            Enemy.SetActive(false);
            PlayerMotionBlock.SetActive(false);
        }
        else
        {
            Debug.LogError("Enemy GameObject not set");
        }
    }
}
