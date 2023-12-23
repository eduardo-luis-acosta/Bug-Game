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
    public float currentHealth = 50f;
    private int maxHealth = 100;
    public int healMode;
    public int damageMode;

    private float defense = 0f;
    private int damage = 5;
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
    public void removeHealth(int remove)
    {
        if(defense > 0)
        {
            float i = (currentHealth + (defense * currentHealth)) - remove;
            currentHealth -= i;
        } else {
            currentHealth -= remove;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Health")
        {
            AddHealth(healMode);
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag == "Damage")
        {
            removeHealth(damageMode);
            Destroy(collision.gameObject);
        }
    }

    private IEnumerator SlowHeal(int time)
    {
        yield return new WaitForSeconds(0.1f);
    }
}
