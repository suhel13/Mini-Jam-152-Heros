using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if (instance != this) 
        {
            Destroy(this);
        }
    }

    [SerializeField] GameObject enemyMelePrefab;
    [SerializeField] GameObject wellPrefab;
    [SerializeField] GameObject animalPrefab;
    [SerializeField] GameObject orePrefab;
    [SerializeField] GameObject enemyBowPrefab;
    [SerializeField] GameObject meatPrefab;
    public GameObject SpawnObstacle(Obstacles.ObstaclesType type, Vector2 pos)
    {
        switch (type)
        {
            case Obstacles.ObstaclesType.EnemyMele:
                return Instantiate(enemyMelePrefab, pos + Vector2.right * Random.Range(-5f, 5f), Quaternion.identity);

            case Obstacles.ObstaclesType.Well:
                return Instantiate(wellPrefab, pos + Vector2.right * Random.Range(-5f, 5f), Quaternion.identity);

            case Obstacles.ObstaclesType.Animals:
                return Instantiate(animalPrefab, pos + Vector2.right * Random.Range(-5f, 5f), Quaternion.identity);

            case Obstacles.ObstaclesType.Ore:
                return Instantiate(orePrefab, pos + Vector2.right * Random.Range(-5f, 5f), Quaternion.identity);

            case Obstacles.ObstaclesType.EnemyBow:
                float temp = Random.Range(-1f, 1f);
                if (temp < 0)
                    return Instantiate(enemyBowPrefab, pos + Vector2.right * Random.Range(-7.2f, -8.2f), Quaternion.Euler(0, 0, 0));
                else
                    return Instantiate(enemyBowPrefab, pos + Vector2.right * Random.Range(7.2f, 8.2f), Quaternion.Euler(0, 180, 0));

            case Obstacles.ObstaclesType.Meat:
                return Instantiate(meatPrefab, pos, Quaternion.identity);

            default:
                return null;
        }
    }
}
