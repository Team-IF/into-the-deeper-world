using UnityEngine;

public class CS : MonoBehaviour
{
    // Start is called before the first frame update
    void Default()
    {
        Screen.SetResolution(1920, 1080, true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}
