using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health;
    [HideInInspector]
    public Transform player;
    public  int damage;
    

    public float speed;
    public float timeBetweenAttacks;
    public int pickedupChances;
    public GameObject[] pickups;

    public int healthPickupChance;
    public GameObject healthPickup;
    public GameObject deadthEffect;
    public GameObject enemyBlood;
 
    // Start is called before the first frame update
    public virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


   public void TakeDamage(int damageAmount){
        Debug.Log("damageAmount:"+damageAmount);
        health -= damageAmount;
        if(health <= 0){
            Debug.Log("ya felpo");
            int randomNumber = Random.Range(0,101);
            if(randomNumber < pickedupChances){
                GameObject randomPickup = pickups[Random.Range(0,pickups.Length)];
                Instantiate(randomPickup,transform.position,transform.rotation);
            }

            int randHealth = Random.Range(0,101);
            if(randHealth < healthPickupChance)
            {
                Instantiate(healthPickup,transform.position,transform.rotation);
            }
            Instantiate(deadthEffect,transform.position,Quaternion.identity);
            Instantiate(enemyBlood,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }
  
}
