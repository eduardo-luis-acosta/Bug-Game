using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;

    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    public int currentHealth = 50;
    private int maxHealth = 100;
    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if(currentHealth > maxHealth)
        {
            currentHealth = 100;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    public void AddHealth(int add)
    {
        currentHealth += add;
    }
}
