using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    public CameraMovement cameraMovement;
    public Dictionary<string, int> villageResourses = new Dictionary<string, int>();
    public List<GameObject> toolsPrefabs = new List<GameObject>();
    public PlayerMovement playerMovement;

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

    public void FromBackpackToVillage()
    {
        foreach(KeyValuePair<string, int> entry in Backpack.instance.inventory)
        {
            AddItemToVillageResourses(entry.Key, entry.Value);
        }
    }
}