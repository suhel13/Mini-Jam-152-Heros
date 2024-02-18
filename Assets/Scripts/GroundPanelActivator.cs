using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GroundPanelActivator : MonoBehaviour
{
    
    [SerializeField] List<Transform> spawnPoints = new List<Transform>();
    private void Start()
    {
        Random.InitState((int)System.DateTime.Now.Ticks);
    }
    public void SpawnObstacles()
    { 
        foreach(Transform t in spawnPoints)
        {
            SpawnObstacle(t.position);
        }    
    }

    public void SpawnObstacle(Vector2 pos)
    {
        float random = Random.Range(0f, 1f)*100;
        //Debug.Log(random);
        if(random < 15f)
        {
            //Debug.Log("Spawn null");
            //spawn nothig
        }
        else if (random < 35f)
        {
            //spawm well
            //Debug.Log("Spawn well");
            SpawnManager.instance.SpawnObstacle(Obstacles.ObstaclesType.Well, pos).transform.SetParent(transform);
        }
        else if(random < 55f)
        {
            //spawn enemy mele
            //Debug.Log("Spawn enemyMele");
            SpawnManager.instance.SpawnObstacle(Obstacles.ObstaclesType.EnemyMele, pos).transform.SetParent(transform);
        }
        else if(random < 75f)
        {
            //spawn enemy bow
            //Debug.Log("Spawn enemyBow");
            SpawnManager.instance.SpawnObstacle(Obstacles.ObstaclesType.EnemyBow, pos).transform.SetParent(transform);
        }
        else if(random < 85f)
        {
            //spawn ore
            //Debug.Log("Spawn ore");
            SpawnManager.instance.SpawnObstacle(Obstacles.ObstaclesType.Ore, pos).transform.SetParent(transform);
        }
        else
        {
            //spawn animal
            //Debug.Log("Spawn animal");
            SpawnManager.instance.SpawnObstacle(Obstacles.ObstaclesType.Animals, pos).transform.SetParent(transform);
        }
    }
}