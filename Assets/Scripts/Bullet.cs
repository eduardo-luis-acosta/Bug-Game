using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 20;
    public GameObject playerobj;
    private Player playerscript;
    void Start()
    {
        playerscript = playerobj.GetComponent<Player>();        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerscript.magic == true)
        {
            transform.Translate(Vector2.up * Time.deltaTime * (speed/3));
        } else {
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
