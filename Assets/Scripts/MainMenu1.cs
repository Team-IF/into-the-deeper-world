using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu1 : MonoBehaviour
{
    // Start is called before the first frame update
    public void RunQuit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void ChangeScene(string scenesName)
    {
        SceneManager.LoadScene(scenesName);
    }

    public void Start(string scenesName1) // but this only Debug
    {
        Debug.Log("Debugging" + scenesName1);
        // SceneManager.LoadScene("scenesName");

    }
}
