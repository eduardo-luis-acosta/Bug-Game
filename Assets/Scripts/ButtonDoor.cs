using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDoor : MonoBehaviour
{
    public GameObject door;
    public GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Button")
        {
            StartCoroutine(DoorProcess(1f));
        }
    }

    private IEnumerator DoorProcess(float waitTime)
    {   
        yield return new WaitForSeconds(0.1f);
        door.GetComponent<Renderer> ().enabled = false;
        door.GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(waitTime);        
        door.GetComponent<Renderer> ().enabled = true;
        door.GetComponent<BoxCollider2D>().enabled = true;
    }
}
