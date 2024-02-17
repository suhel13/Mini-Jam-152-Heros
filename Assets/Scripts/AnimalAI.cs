using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalAI : MonoBehaviour
{
    [SerializeField] float escapeTrigerRange;
    [SerializeField] float speed;
    bool isEscaping = false;

    void Update()
    {
        if(Vector2.Distance(transform.position, GameManager.instance.playerMovement.transform.position) < escapeTrigerRange)
        {
            isEscaping = true;
        }
        if(isEscaping)
        {
            if((transform.position - GameManager.instance.playerMovement.transform.position).x >= 0)
            {

                Debug.Log("normal");
                transform.eulerAngles.Set(0, 0, 0);
            }
            else
            {
                Debug.Log("reverse");
                transform.eulerAngles.Set(0, 180, 0);
            }

            transform.position += (transform.position - GameManager.instance.playerMovement.transform.position).normalized * speed * Time.deltaTime;
        }

        if(Vector2.Distance(transform.position, GameManager.instance.cameraMovement.transform.position) > 15)
        {
            Destroy(gameObject);
        }
    }
}
