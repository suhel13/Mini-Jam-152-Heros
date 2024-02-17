using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Vector3 targetPos;
    [SerializeField] float speed;
    Rigidbody2D rb2D;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    public void SetVelocity( Vector3 targetPos)
    {
        rb2D.velocity = (targetPos - transform.position ).normalized * speed;
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, GameManager.instance.cameraMovement.transform.position) > 20)
        {
            Destroy(gameObject);
        }
    }
}