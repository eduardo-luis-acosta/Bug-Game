using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D bullet;
    public GameObject player;
    public bool shoot;
    void Start()
    {
        StartCoroutine("ShootBullet");
    }

    // Update is called once per frame
    void Update()
    {
        


    }

    IEnumerator ShootBullet()
    {
        while(shoot)
        {
            Rigidbody2D clone;
            clone = Instantiate(bullet, transform.position, transform.rotation);

            clone.AddForce(player.transform.position * 1f, ForceMode2D.Impulse);

            yield return new WaitForSeconds(2f);
        }
    }
}
