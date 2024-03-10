using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class flyEnemny : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed;
    public float rotationModifier;
    public float health;
    private GameObject player;
    private Transform target;
    public bool activated;
    public bool returnseq;
    private Vector3 startingPos;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        target = player.GetComponent<Transform>();
        startingPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(activated){
            float movement = Random.Range(0.0f, 1.0f) * Time.deltaTime;
            Vector2 position = transform.position + new Vector3(0, movement, 0);

            float step = moveSpeed * Time.deltaTime * 0.5f;
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);

            //transform.LookAt(target);
            Vector3 vectorToTarget = player.transform.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - rotationModifier;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotationSpeed);
        }

        if(returnseq && !activated)
        {
            transform.position = Vector3.MoveTowards(transform.position, startingPos, moveSpeed * Time.deltaTime);
        }

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
