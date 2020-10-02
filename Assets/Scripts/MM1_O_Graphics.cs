using UnityEngine;

public class MM1_O_Graphics : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("initializing MM1_O_Graphics.cs");
    }

    public void WindowMode(int value)
    {
        if (value == 0)
        {
            Screen.SetResolution(1920, 1080, true);
        }
        else if (value == 1)
        {
            Screen.SetResolution(1280, 720, false);
        }
    }

    // Update is called once per frame
    private void Update() //
    {
        // No Sciprt Here :(
    }
}