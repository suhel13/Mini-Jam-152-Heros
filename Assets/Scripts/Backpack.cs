using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backpack : MonoBehaviour
{
    [SerializeField] Sprite watherIcon;
    [SerializeField] Sprite meatIcon;
    [SerializeField] Sprite ironIcon;

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
        if (inventory.ContainsKey(name))
        {
            inventory[name] += amount;
            GameManager.instance.backpackUIPanelControler.UpdateItemUIControler(name, inventory[name]);
        }
        else
        {
            inventory.Add(name, amount);
            GameManager.instance.backpackUIPanelControler.CreateItemUIControler(name, GetIconByName(name) ,amount);
        }
    }

    public Sprite GetIconByName(string name)
    {
        switch (name)
        {
            case "Wather":
                return watherIcon;
            case "Meat":
                return meatIcon;
            case "IronOre":
                return ironIcon;
            default:
                Debug.Log(name + " - Wrong name no Icon");
                return null;
        }
    }

}