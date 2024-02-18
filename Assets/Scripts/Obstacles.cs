using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    [HideInInspector] public bool canPlayerInteract = true;
    [SerializeField] string itemName;
    [SerializeField] int amount;
    [SerializeField] GameObject unUsedSprite;
    [SerializeField] GameObject usedSprite;

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

    private void Start()
    {
        if(usedSprite)
            usedSprite.SetActive(false);
    }
    public virtual void interact()
    {
        canPlayerInteract = false;
        unUsedSprite.SetActive(false);

        if (usedSprite == null)
        {
            Destroy(gameObject);
        }
        else
        {
            usedSprite.SetActive(true);
        }
    }
}