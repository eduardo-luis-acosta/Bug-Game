using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public TextMeshProUGUI statsBox;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    private float currentHealth = 50f;
    private int maxHealth = 100;

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
        statsBox.text = "Health " + currentHealth + " \n Defense: " + defense + " \n";
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    public void AddHealth(int add)
    {
        currentHealth += add;
    }
    public void removeHealth(float remove)
    {
        if(defense > 0)
        {
            float i = remove  * (1 - (defense/(100 + defense)));
            currentHealth -= i;
        } else {
            currentHealth -= remove;
        }
    }
    public void addDefense(float add)
    {
        defense += add;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Health")
        {
            AddHealth(30);
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag == "Damage")
        {
            removeHealth(20.0f);
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag == "Defense")
        {
            addDefense(10f);
            Destroy(collision.gameObject);
        }
    }

    private IEnumerator SlowHeal(int time)
    {
        yield return new WaitForSeconds(0.1f);
    }
}
