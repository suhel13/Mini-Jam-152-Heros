using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backpack : MonoBehaviour
{
    public static Backpack instance { get; private set; }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
    }

    public Dictionary<string,  int> inventory = new Dictionary<string, int>();

    public void AddItemToInventory(string name, int amount)
    {
        if (!inventory.ContainsKey(name))
            inventory[name] += amount;
        else
            inventory.Add(name, amount);
    }
}