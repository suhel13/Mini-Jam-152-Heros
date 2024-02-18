using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongRangeInteract : MonoBehaviour
{
    ToolsManager toolsManager;

    // Start is called before the first frame update
    void Start()
    {
        toolsManager = GetComponentInParent<ToolsManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (toolsManager != null)
        {
            toolsManager.InteractLongRange(collision);
        }
    }
}