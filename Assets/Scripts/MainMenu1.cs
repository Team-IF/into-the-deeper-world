using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu1 : MonoBehaviour
{
    public void StartGame() // but this only Debug 
    {
    }
    public void RunQuit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void ChangeScene(string scenesName)
    {
        SceneManager.LoadScene(scenesName);
    }

    void Start()
    {
        Debug.Log("initializing MainMenu1.cs");
    }
    void Update()
    {
    }
}
