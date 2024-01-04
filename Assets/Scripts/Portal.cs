using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    // Start is called before the first frame update
    
    public GameObject endPoint;
    public GameObject startPoint;
    private GameObject parent;
    void Start()
    {
        //parent = GetComponent<>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
       
    }
}
