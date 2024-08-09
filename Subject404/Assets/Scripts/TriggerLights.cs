using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLights : MonoBehaviour
{
    public GameObject topLights;
    public GameObject bottomLights;
    public GameObject sound;
    public GameObject gameSound;
    public GameObject gameInstructions;
    public GameObject playerDialogue;
    private StateManagerScene6 stateManager;
    public Camera mainCamera;
    private Raycast _raycaster;
    public GameObject enemy;

    void Start()
    {
         _raycaster = mainCamera.GetComponent<Raycast>();
        stateManager = gameInstructions.GetComponent<StateManagerScene6>();
    }

    void OnTriggerEnter(Collider other)
    {
        bottomLights.SetActive(false);
        sound.SetActive(true);
        topLights.SetActive(true);
        stateManager.SetSceneState(1);
        
        StartCoroutine(WaitForPlayerToViewEnemy());
    }

    private IEnumerator WaitForPlayerToViewEnemy()
    {
        while (!_raycaster.IsObjectInView(enemy))
        {
            yield return null;
        }

        playerDialogue.SetActive(true);
        yield return new WaitForSeconds(3);
        gameSound.SetActive(true);
    }
}
