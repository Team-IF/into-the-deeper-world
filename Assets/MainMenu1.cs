using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu1 : MonoBehaviour
{
    // Start is called before the first frame update
    public void RunQuit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void GoOptionsScene()
    {
        SceneManager.LoadScene("Scenes/Scenes2");
    }

    public void GoMain_menuScene()
    {
        SceneManager.LoadScene("Scenes/Scenes1");
    }

    public void HD()
    {
        Screen.SetResolution(1280,720,false);
    }
}
