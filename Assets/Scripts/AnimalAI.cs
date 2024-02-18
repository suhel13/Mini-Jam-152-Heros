using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalAI : MonoBehaviour, IDeathAble
{
    [SerializeField] float escapeTrigerRange;
    [SerializeField] float speed;
    bool isEscaping = false;

    public void Death()
    {
        SpawnManager.instance.SpawnObstacle(Obstacles.ObstaclesType.Animals, transform.position);
        Destroy(gameObject);
    }

    void Update()
    {
        if(Vector2.Distance(transform.position, GameManager.instance.playerMovement.transform.position) < escapeTrigerRange)
        {
            isEscaping = true;
        }
        if (isEscaping)
        {
            if ((transform.position - GameManager.instance.playerMovement.transform.position).x >= 0)
            {
                Debug.Log("normal");
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else
            {
                Debug.Log("reverse");
                transform.eulerAngles = new Vector3(0, 180, 0);
            }

            transform.position += (transform.position - GameManager.instance.playerMovement.transform.position).normalized * speed * Time.deltaTime;
        }

        if(Vector2.Distance(transform.position, GameManager.instance.cameraMovement.transform.position) > 15)
        {
            Destroy(gameObject);
        }
    }
}