using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    [SerializeField] GameObject groundPanelPrefab;
    [SerializeField] List<GameObject> groundPanels = new List<GameObject>();
    
    void GeneradeGroundPanel()
    {
        if(groundPanels.Count > 1)
        {
            Destroy(groundPanels[0]);
            groundPanels.RemoveAt(0);
        }

        groundPanels.Add(Instantiate(groundPanelPrefab, groundPanels[0].transform.position + Vector3.up * 20, Quaternion.identity));
        groundPanels[1].GetComponent<GroundPanelActivator>().SpawnObstacles();
        groundPanels[1].transform.parent = transform;
    }

    private void Update()
    {
        if( groundPanels.Count <2 ) 
        {
            GeneradeGroundPanel();
        }
        if (groundPanels[1].transform.position.y < GameManager.instance.cameraMovement.transform.position.y)
        {
            GeneradeGroundPanel();
        }
    }
}