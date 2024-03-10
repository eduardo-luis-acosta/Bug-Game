using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public GameObject bullet;
    public TextMeshProUGUI statsBox;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public flyEnemny flyEnemnyScript;
    Vector2 movement;
    private float currentHealth;
    private int maxHealth = 100;

    private float defense = 0f;
    private int damage = 5;

    //bullet type testing
    public bool magic = false;




    //Boolean from "PauseMenu" Script
    static bool pause;

    //Health Bar variable
    public HealthBar health;

    //Armor variable
    public Armor armor;



    void Start() {

        //Start the game with Max Health and Set Health Bar to Max Health
        currentHealth = maxHealth;
        health.setMaxHealth(maxHealth);
        armor.setArmor(0);

    }

    // Update is called once per frame
    void Update()
    {
        pause = PauseMenu.IsPaused;

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

        //Will freeze player rotation to mouse when pause menu is active
        //Will unfreeze player rotation to mouse when pause menu is not active
        if(pause == true) {
            direction = new Vector2(0,0);
        } else if (pause == false) {
            direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        }

        transform.up = direction;

        if(currentHealth > maxHealth)
        {
            currentHealth = 100;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            shootBullet();
        }
        //statsBox.text = "Health " + currentHealth + " \n Defense: " + defense + " \n";

        //TESTING. - Eddie :3
        if(Input.GetKeyDown(KeyCode.X))
        {
            removeHealth(10);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
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
            health.setHealth(currentHealth);
        }
    }
    public void addDefense(float add)
    {
        defense += add;
        armor.setArmor(add);
    }

    void shootBullet()
    {
        Instantiate(bullet, transform.position, transform.rotation);
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
            addDefense(40f);
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag == "enemyArea")
        {
            flyEnemnyScript.activated = true;
        }

        if(collision.gameObject.tag == "magic")
        {
            magic = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "enemyArea")
        {
            flyEnemnyScript.activated = false;
            flyEnemnyScript.returnseq = true;
        }
    }

    private IEnumerator SlowHeal(int time)
    {
        yield return new WaitForSeconds(0.1f);
    }

}
