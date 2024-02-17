using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolButton : MonoBehaviour
{
    [SerializeField] GameObject toolPrefab;
    bool isSeleced;
    [SerializeField] GameObject selectedBorder;

    private void Awake()
    {
        selectedBorder.SetActive(false);
        isSeleced = false;
    }

    public void select()
    {
        if (isSeleced)
        {
            isSeleced = false;
            selectedBorder.SetActive(false);
            GameManager.instance.toolsPrefabs.Remove(toolPrefab);
        }
        else
        {
            if (GameManager.instance.toolsPrefabs.Count < 2)
            {
                isSeleced = true;
                selectedBorder.SetActive(true);
                GameManager.instance.toolsPrefabs.Add(toolPrefab);
            }
        }
    }


}
