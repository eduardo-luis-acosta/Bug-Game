using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 100f;
    public GameObject playerobj;
    private Player playerscript;
    public Sprite magicSprite;
    public Sprite baseBullet;
    void Start()
    {
        playerscript = playerobj.GetComponent<Player>();   
        this.gameObject.GetComponent<SpriteRenderer>().sprite = baseBullet;     
    }

    // Update is called once per frame
    void Update()
    {
        if(playerscript.getBulletType().Equals("magic"))
        {
            speed = 15f;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = magicSprite;
            transform.Translate(Vector2.up * Time.deltaTime * speed);
        } else {
            speed = 100f;
            transform.Translate(Vector2.up * Time.deltaTime * speed);
        }
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }

}
