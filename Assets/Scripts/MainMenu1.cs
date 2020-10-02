using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu1 : MonoBehaviour
{
    public void StartGame()
    {
        // but this only Debug
        Debug.Log("Start button work");
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

    private void Start()
    {
        Debug.Log("initializing MainMenu1.cs");
    }

    // Update is called once per frame
    private void Update()
    {
        // No Sciprt Here :(
    }
}