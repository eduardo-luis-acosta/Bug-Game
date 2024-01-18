using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float health;
    private GameObject player;
    public GameObject area;
    private Vector3 startingPos;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        startingPos = transform.position;
        //area = this.GameObject.GetComponentInParent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float step = moveSpeed * Time.deltaTime * 0.5f;
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
    }
}
