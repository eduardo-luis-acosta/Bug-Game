using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTest : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;

    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    private int currentHealth = 50;
    private int maxHealth = 100;
    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}