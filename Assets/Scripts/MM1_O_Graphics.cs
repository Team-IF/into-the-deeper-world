﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MM1_O_Graphics : MonoBehaviour
{
    void Start()
    {
        Debug.Log("initializing MM1_O_Graphics.cs");
    }

    public Dropdown dropdown;
    public void WindowMode(int value)
    {
        switch (value)
        {
            case 0:
            {
                Screen.SetResolution (1920, 1080, true);
                break;
            }

            case 1:
            {
                Screen.SetResolution(1280, 720, false);
                break;
            }
        }
    }

    void Update()
    {
    }
}