using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float playerSpeed;
    Vector2 inputVector;
    Rigidbody2D rb2D;
    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        rb2D.velocity = inputVector.normalized * playerSpeed;
        rb2D.velocity += Vector2.up * GameManager.instance.cameraMovement.cameraSpeed;
    }
}
