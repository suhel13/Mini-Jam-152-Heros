using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsManager : MonoBehaviour
{
    [SerializeField] List<Tools> tools = new List<Tools>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Obstacles obstacle;
        if( collision.TryGetComponent<Obstacles>(out obstacle))
        {
            foreach(Tools tool in tools)
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
