using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collider2D collision)
    {
        //start dialog
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("you entered my difficulty domain");
        }
    }

    void OnCollisionExit2D(Collider2D collision)
    {
        //end dialog
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("bye nerd");
        }
    }
}
