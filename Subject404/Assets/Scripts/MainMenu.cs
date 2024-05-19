using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ChangeScene(int sceneId){
        SceneManager.LoadScene(sceneId);
    }
    public void ExitGame(){
        Debug.Log("Session terminated successfully");
        Application.Quit();
    }
}
