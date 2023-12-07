using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    private Player PlayerScript;
    public int healMode;

    // Start is called before the first frame update
    void Start()
    {
        PlayerScript = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Health")
        {
            PlayerScript.AddHealth(healMode);
            Destroy(collision.gameObject);
        }
    }

    private IEnumerator SlowHeal(int time)
    {
        yield return new WaitForSeconds(0.1f);
    }
}
