using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    Player playerScript;
    public int healAmount;
    public GameObject effect;
    public GameObject soundObject;
    // Start is called before the first frame update
    void Start()
    {
       playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>(); //aqui poner un trycatch cuando te mueres
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Player"){
            Instantiate(effect,transform.position,Quaternion.identity);
            Instantiate(soundObject,transform.position,transform.rotation);
            playerScript.Heal(healAmount);
            Destroy(gameObject);
        }
    }
 
}
