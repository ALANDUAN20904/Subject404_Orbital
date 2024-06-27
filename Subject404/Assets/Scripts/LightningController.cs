using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningController : MonoBehaviour
{
     private bool _lightningTimed;
     public GameObject LightningSource;
     void Start()
     {
          if (LightningSource == null)
          {
               Debug.LogError("Lightning Source not set");
          }
          _lightningTimed = false;
     }
     void Update()
     {
          if (!_lightningTimed) StartCoroutine(ControlLightning(Random.Range(0, 20)));
     }
     private IEnumerator ControlLightning(int time)
     {
          _lightningTimed = true;
          yield return new WaitForSeconds(time);
          LightningSource.SetActive(true);
          yield return new WaitForSeconds(0.01F);
          LightningSource.SetActive(false);
          _lightningTimed = false;
     }
}
