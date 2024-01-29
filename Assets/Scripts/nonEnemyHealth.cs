using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nonEnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float health = 100f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0){
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet"){
            Destroy(collision.gameObject);
            health -= 10;
        }
    }

}
