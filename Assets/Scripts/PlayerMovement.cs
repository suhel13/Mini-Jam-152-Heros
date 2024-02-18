using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IDeathAble
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
        inputVector.x = Input.GetAxisRaw("Horizontal");
        inputVector.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        if (GameManager.instance.state == GameManager.gameState.Run)
        {
            rb2D.velocity = inputVector.normalized * playerSpeed;
            rb2D.velocity += Vector2.up * GameManager.instance.cameraMovement.cameraSpeed;
        }
    }

    public void Death()
    {
        GameManager.instance.SwitchToState(GameManager.gameState.EndScrean);
    }
}
