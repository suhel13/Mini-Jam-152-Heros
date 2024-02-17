using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    [HideInInspector] public bool canPlayerInteract = true;
    [SerializeField] string itemName;
    [SerializeField] int amount;

    [Flags]
    public enum ObstaclesType
    {
        EnemyMele = 1,
        Well = 2,
        Animals = 4,
        Ore = 8,
        Meat = 16,
        EnemyBow = 32
    }

    public ObstaclesType type;
    public virtual void interact()
    {
        canPlayerInteract = false;
    }
}