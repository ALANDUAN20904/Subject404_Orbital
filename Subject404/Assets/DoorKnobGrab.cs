using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DoorKnobGrab : MonoBehaviour
{
    public GameObject cultist;
    public Vector3 teleportPosition1;
    public Vector3 teleportPosition2;
    public float reappearDelay1 = 3.0f;
    public float reappearDelay2 = 7.0f;
    private XRGrabInteractable grabInteractable;
    private bool _isGrabbed = false;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.selectEntered.AddListener(OnDoorknobGrabbed);

        //test
        //SimulateGrab();
    }

    void OnDoorknobGrabbed(SelectEnterEventArgs args)
    {
        if (!_isGrabbed)
        {
            _isGrabbed = true;
            StartCoroutine(cultistBehavior());
            grabInteractable.enabled = false;
        }
    }

    IEnumerator cultistBehavior()
    {
        cultist.SetActive(false);
        cultist.transform.position = teleportPosition1;
        yield return new WaitForSeconds(reappearDelay1);
        cultist.SetActive(true);

        yield return new WaitForSeconds(reappearDelay2 - reappearDelay1);
        cultist.SetActive(false);
        cultist.transform.position = teleportPosition2;
        yield return new WaitForSeconds(0.5f); // Short delay before reappearing
        cultist.SetActive(true);

    }

    /*
    void SimulateGrab()
    {
        OnDoorknobGrabbed(null);
    }
    */
    
}
