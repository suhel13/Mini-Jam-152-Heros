using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public CameraMovement cameraMovement;

    public Dictionary<string, int> villageResourses = new Dictionary<string, int>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(this);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void AddItemToVillageResourses(string name, int amount)
    {
        if (!villageResourses.ContainsKey(name))
            villageResourses[name] += amount;
        else
            villageResourses.Add(name, amount);
    }

    public void FromBackPackToVillage()
    {
        foreach(KeyValuePair<string, int> entry in BackPack.instance.inventory)
        {
            AddItemToVillageResourses(entry.Key, entry.Value);
        }
    }
}