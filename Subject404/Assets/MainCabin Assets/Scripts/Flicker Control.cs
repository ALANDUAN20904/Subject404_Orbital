using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This function flickers the spot light in a random pattern

public class FlickerControl : MonoBehaviour
{
    public bool isFlickering = false;
    public float TimeDelay;

    void Update()
    {
        if (isFlickering == false)
        {
            StartCoroutine(FlickeringLight());
        }
    }

    IEnumerator FlickeringLight()
    {
        isFlickering = true;
        this.gameObject.GetComponent<Light>().enabled = false;

        //The smaller the range, the faster the light flickers
        TimeDelay = Random.Range(0.01f, 0.4f);
        yield return new WaitForSeconds(TimeDelay);

        this.gameObject.GetComponent<Light>().enabled = true;
        TimeDelay = Random.Range(0.1f, 0.4f);
        yield return new WaitForSeconds(TimeDelay);

        isFlickering = false;
    }
}



