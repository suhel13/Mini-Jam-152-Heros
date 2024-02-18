using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float cameraSpeed;
    Rigidbody2D rb2D;
    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (GameManager.instance.state == GameManager.gameState.Run)
        {
            rb2D.velocity = Vector2.up * cameraSpeed;
        }
        else
        {
            rb2D.velocity = Vector2.zero;
        }
    }
}
