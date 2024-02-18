using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    public CameraMovement cameraMovement;
    public ItemUIPanelControler backpackUIPanelControler;
    
    public Dictionary<string, int> villageResourses = new Dictionary<string, int>();
    public ItemUIPanelControler villageUIPanelControler;
    public List<GameObject> toolsPrefabs = new List<GameObject>();
    public PlayerMovement playerMovement;

    public enum gameState { Village, ToolSelect, Run, EndScrean }
    public gameState state;
    public GameObject VillagePanel;
    public GameObject ToolSelectPanel;
    public GameObject level;
    public GameObject levelPrefab;
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
    void Start()
    {
        backpackUIPanelControler = level.GetComponentInChildren<ItemUIPanelControler>();
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
                ResetLevel();
                ToolSelectPanel.SetActive(true);
                break;
            case gameState.Run:
                BeginRun();
                break;
            case gameState.EndScrean:
                EndScreanPanel.SetActive(true);
                break;
            default:
                break;
        }

        state = nextState;
    }
    void ResetLevel()
    {
        Destroy(level);
        level = Instantiate(levelPrefab, Vector3.zero, Quaternion.identity);
        cameraMovement.transform.position = new Vector3(0, -5, -10);
        playerMovement = level.GetComponentInChildren<PlayerMovement>();
        backpackUIPanelControler = level.GetComponentInChildren<ItemUIPanelControler>();
    }

    void BeginRun()
    {
        if (toolsPrefabs.Count < 1)
            return;
        if (toolsPrefabs.Count < 2)
        {
            playerMovement.GetComponentInChildren<ToolsManager>().AddTools(toolsPrefabs[0], null);
            return;
        }
        if(toolsPrefabs.Count < 3)
        {
            playerMovement.GetComponentInChildren<ToolsManager>().AddTools(toolsPrefabs[0], toolsPrefabs[1]);
            return;
        }
    }
}