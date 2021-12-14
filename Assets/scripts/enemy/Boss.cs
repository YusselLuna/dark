using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public int health;
    public Enemy[] enemies;
    public float spawnOffset;
    private int halfHealth;
    private Animator animator;
    public int damage;

    public GameObject deadthEffect;
    public GameObject enemyBlood;

    private Slider healthBar;
    // Start is called before the first frame update
    void Start()
    {
        halfHealth = health / 2;
        animator = GetComponent<Animator>();
        healthBar = FindObjectOfType<Slider>();
        healthBar.maxValue = health;
        healthBar.value = health;

    }

       public void TakeDamage(int damageAmount){
           Debug.Log("LE PEGO AL BOSS");
        health -= damageAmount;
        healthBar.value = health;
        if(health <= 0){
            Debug.Log("ya chafio el Boss");
            Instantiate(deadthEffect,transform.position,Quaternion.identity);
            Instantiate(enemyBlood,transform.position,Quaternion.identity);
            Destroy(gameObject);
            healthBar.gameObject.SetActive(false);
        }
        if(health <= halfHealth)
        {
            animator.SetTrigger("stage2");
        }

        Enemy randomEnemy = enemies[Random.Range(0,enemies.Length)];
        Instantiate(randomEnemy,transform.position + new Vector3(spawnOffset,spawnOffset,0),transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("TE PEGO:"+collision.tag);
        if(collision.tag == "Player")
        {
            collision.GetComponent<Player>().TakeDamage(damage);
        }
        
    }
}
