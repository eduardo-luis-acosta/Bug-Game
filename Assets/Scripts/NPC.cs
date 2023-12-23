using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC : MonoBehaviour
{
    // Start is called before the first frame update
    private bool playerDetect = false;
    private bool playerEng = false;
    public GameObject dialoguecanvas;
    public GameObject fCanvas;
    public GameObject npcObj;
    public TextMeshProUGUI textBox;


    public List<string> dialogList = new List<string>();

    private int option = 0;
    void Start()
    {
        textBox.text = dialogList[option];
    }

    // Update is called once per frame
    void Update()
    {
        if(playerDetect && Input.GetKeyDown(KeyCode.F))
        {
            fCanvas.gameObject.SetActive(false);
            dialoguecanvas.gameObject.SetActive(true);
            playerEng = true;
        }

        if(Input.GetKeyUp(KeyCode.Space) && playerEng)
        {
            cycleDialogue();
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
            playerEng = false;
            fCanvas.gameObject.SetActive(false);
            dialoguecanvas.gameObject.SetActive(false);
        }
    }

    void cycleDialogue()
    {
        //dialogue cycle with prompt
        option++;
        if(option > dialogList.Count - 1)
        {
            option = 0;
        }

        textBox.text = dialogList[option];
    }
}
