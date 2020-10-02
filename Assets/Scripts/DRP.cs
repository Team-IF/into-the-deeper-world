using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Discord;
using System;
using System.Diagnostics;
using System.ComponentModel;
public class DRP : MonoBehaviour
{
    void Start()
    {
        var now = DateTime.Now.ToLocalTime(); 
        var span = (now - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime());
        var activity = new Discord.Activity
        {
            State = "Into the Deeper world",
            Details = "Waiting",
            Timestamps =
            {
                Start = (int)span.TotalSeconds
            },
            Assets =
            {
                LargeImage = "logo",
                LargeText = null,
                SmallImage = "teamif",
                SmallText = null,
            },
        };
    }
    void Update()
    {
        var discord = new Discord.Discord(756805917944578112, (UInt64)Discord.CreateFlags.Default);
        discord.RunCallbacks();
    }
}