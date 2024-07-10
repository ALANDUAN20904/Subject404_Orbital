using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public GameObject currCamera;
    public GameObject player;
    public void OnAnimationEnd()
    {
        player.SetActive(true);
        currCamera.SetActive(false);
    }
}
