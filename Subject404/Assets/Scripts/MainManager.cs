using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    private bool _isSafe = false;
    public static MainManager Instance;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void SetSafe()
    {
        _isSafe = true;
    }
    public bool GetSafe(){
        return _isSafe;
    }
}