using System;  
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Discord;

public class DRP : MonoBehaviour
{
    public Discord.Discord discord;

    void Start()
    {
        discord = new Discord.Discord(756805917944578112, (UInt64)Discord.CreateFlags.Default);
        var now = DateTime.Now.ToLocalTime();
        var span = (now - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime());
        var activityManager = discord.GetActivityManager();
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
        activityManager.UpdateActivity(activity, (result) =>
        {
            if (result == Discord.Result.Ok)
            {
                Debug.LogError("Everything is fine!");
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        discord.RunCallbacks();
    }
}