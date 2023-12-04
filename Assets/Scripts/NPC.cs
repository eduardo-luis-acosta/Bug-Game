using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    // Start is called before the first frame update
    private bool playerDetect = false;
    private bool canvasActivate = true;
    public GameObject dialoguecanvas;
    public GameObject fCanvas;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerDetect && Input.GetKeyDown(KeyCode.F))
        {
            fCanvas.gameObject.SetActive(false);
            dialoguecanvas.gameObject.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //start dialog
        if(collision.gameObject.tag == "Player")
        {
            playerDetect = true;
            fCanvas.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        //end dialog
        if(collision.gameObject.tag == "Player")
        {
            playerDetect = false;
            fCanvas.gameObject.SetActive(false);
            dialoguecanvas.gameObject.SetActive(false);
        }
    }
}
