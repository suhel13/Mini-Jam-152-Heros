using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    [SerializeField] ToolsType type;
    public Obstacles.ObstaclesType canInteractWithType;
    public void interact()
    { 
        
    }
}
