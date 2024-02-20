using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Tools : MonoBehaviour
{
    [Flags] public enum ToolsType
    {
        Sword = 1,
        Shield = 2,
        Buckett = 4,
        Bow = 8,
        Picaxe = 16,
        Hands = 32
    }

    public ToolsType type;
    public Obstacles.ObstaclesType canInteractWithType;

    public virtual void interact()
    {
        GetComponent<AudioSource>().Play();       
    }
}
