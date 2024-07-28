using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class ChangeToScene : MonoBehaviour
{
    public int winSceneIndex;
    public int loseSceneIndex;
    public VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer.loopPointReached += OnVideoEnd;
    }
    void OnDestroy()
    {
        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached -= OnVideoEnd;
        }
    }
    void OnVideoEnd(VideoPlayer vp)
    {
        if (MainManager.Instance.GetSafe())
        {
            SceneManager.LoadScene(winSceneIndex);
        }
        else
        {
            SceneManager.LoadScene(loseSceneIndex);
        }
    }
}
