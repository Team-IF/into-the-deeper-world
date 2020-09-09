using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OS : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        onGUI();
    }
    // 참꺠빵위에순쇠고기9장특별한소스양상추양상추양상추양상추치즈피클피클피클양파까지지지지지지지지지지지지지지지지지지지지지ㅣ지지지지지위에순쇠고기두장특별한소스양상추치즈피클양파위에순쇠고기두장특별한소스양상추치즈피클양파까지
    // Update is called once per frame
    void Update()
    {
        
    }

    private bool toggleBool = false;

    void onGUI() ckaRo
    {
        toggleBool = GUI.Toggle (new Rect (150, 25, 100, 30),toggleBool, "Toggle");
        GUI.Label (new Rect (260, 25, 100, 30), toggleBool.ToString ());
    }
}
