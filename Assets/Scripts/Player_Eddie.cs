using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.UI;

public class Player_Eddie : MonoBehaviour
{

    //Player Object
    public GameObject player;


    //Player Movement Variables
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;


    //Player Health Variables
    public int maxHealth = 100;
    public int currentHealth;
    public Health health;

    //Player Armor Variables
    public int maxArmor = 100;
    public int currentArmor;
    public Armor armor;


    void Start()
    {
        //Start Health = 100 at Game Start
        currentHealth = maxHealth;
        health.setMaxHealth(maxHealth);

        currentArmor = 0;
        armor.setArmor(currentArmor);
    }

    void Update()
    {
        //Movement Keys
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");



        if(Input.GetKeyDown(KeyCode.Space)) {
            Damage(10);
        }
        
    }

    void FixedUpdate()
    {
        //Rigid Body Position Speed
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }


    void Damage(int damage) {

        //Set Health Int and HealthBar
        currentHealth -= damage;
        health.setHealth(currentHealth);

        if(currentHealth == 0) {
            
        }
    }
}
