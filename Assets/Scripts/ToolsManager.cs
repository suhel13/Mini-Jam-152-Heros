using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ToolsManager : MonoBehaviour
{
    [SerializeField] List<Tools> tools = new List<Tools>();
    [SerializeField] List<Transform> toolsPositions = new List<Transform>();

    public void AddTools(GameObject tool1Prefab, GameObject tool2Prefab)
    {
        if (tool1Prefab != null)
        {
            GameObject tempGO = Instantiate(tool1Prefab);
            tempGO.transform.parent = transform;
            tempGO.transform.position = toolsPositions[0].position;
            tools.Add(tempGO.GetComponent<Tools>());
        }

        if(tool2Prefab != null)
        {
            GameObject tempGO = Instantiate(tool2Prefab);
            tempGO.transform.parent = transform;
            tempGO.transform.position = toolsPositions[1].position;
            tools.Add(tempGO.GetComponent<Tools>());
        }
    }
    public void InteractLongRange(Collider2D collision)
    {
        if (GameManager.instance.state == GameManager.gameState.Run)
        {
            Obstacles obstacle;
            if (collision.TryGetComponent<Obstacles>(out obstacle))
            {
                foreach (Tools tool in tools)
                {
                    if (tool != null)
                    {
                        if (tool.type == Tools.ToolsType.Bow && (tool.canInteractWithType & obstacle.type) == obstacle.type)
                        {
                            if (obstacle.canPlayerInteract)
                            {
                                Debug.Log("Interact");
                                //Spagetti code
                                (tool as Bow).interact(obstacle.transform.position);
                            }
                        }
                    }
                }
            }
        }
    }    
    
    public void InteractShortRange(Collider2D collision)
    {
        if (GameManager.instance.state == GameManager.gameState.Run)
        {
            Obstacles obstacle;
            if (collision.TryGetComponent<Obstacles>(out obstacle))
            {
                foreach (Tools tool in tools)
                {
                    if (tool != null)
                    {
                        if ((tool.canInteractWithType & obstacle.type) == obstacle.type)
                        {
                            if (obstacle.canPlayerInteract)
                            {
                                Debug.Log("Interact");
                                obstacle.interact();
                                tool.interact();
                            }
                        }
                    }
                }
            }
        }
    }
}
