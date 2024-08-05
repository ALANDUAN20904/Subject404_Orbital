using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockerChecker : MonoBehaviour
{
    public GameObject blocker;
    public GameObject[] otherCultists;
    public float delay = 7.0f;
    private bool _hasCollided= false;

    void Start()
    {
        if (blocker != null) 
        { 
            blocker.SetActive(false);   
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !_hasCollided)
        {
            _hasCollided = true;
            GetComponent<Collider>().enabled = false;
            Invoke("showBlocker", delay);

            TriggerAllDisappear();
            
        }
    }

    private void TriggerAllDisappear()
    {
        foreach (GameObject cultist in otherCultists)
        {
            scene7OtherCultistController cultistController = cultist.GetComponent<scene7OtherCultistController>();
            cultistController.TriggerDisappear();
        }
    }

    private void showBlocker()
    {
        if (blocker!=null)
        {
            blocker.SetActive(true);
        }
    }
    
}
