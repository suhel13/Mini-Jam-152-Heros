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

    public enum gameState { Village, ToolSelect, Run, EndScrean }
    public gameState state;
    public GameObject VillagePanel;
    public GameObject ToolSelectPanel;
    public GameObject Run;
    public GameObject EndScreanPanel;

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
        foreach (KeyValuePair<string, int> entry in Backpack.instance.inventory)
        {
            AddItemToVillageResourses(entry.Key, entry.Value);
        }
    }

    public void SwitchToState(gameState nextState)
    {
        //Resolve ending from state
        switch (state)
        {
            case gameState.Village:
                VillagePanel.SetActive(false);
                break;
            case gameState.ToolSelect:
                ToolSelectPanel.SetActive(false);
                break;
            case gameState.Run:
                
                break;
            case gameState.EndScrean:
                EndScreanPanel.SetActive(false);
                break;
            default:
                break;
        }

        //Resolve entering next state
        switch (nextState)
        {
            case gameState.Village:
                VillagePanel.SetActive(true);
                break;
            case gameState.ToolSelect:
                ToolSelectPanel.SetActive(true);
                break;
            case gameState.Run:
                //Reset run
                break;
            case gameState.EndScrean:
                EndScreanPanel.SetActive(true);
                break;
            default:
                break;
        }

        state = nextState;
    }
}