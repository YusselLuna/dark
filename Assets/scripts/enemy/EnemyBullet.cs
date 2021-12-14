using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Player playerScript;
    private Vector2 targetPosition;
    public float speed;
    public int damage;
    public GameObject effect;
    // Start is called before the first frame update
    private void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();        
        targetPosition = playerScript.transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        //if anterior
        // if(Vector2.Distance(transform.position,targetPosition)> 0.1f){

        //     transform.position = Vector2.MoveTowards(transform.position,targetPosition,speed * Time.deltaTime);
        // }else{
        //     Destroy(gameObject);
        // }
        if((Vector2)transform.position == targetPosition)
        {
            Instantiate(effect,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }else{
            transform.position = Vector2.MoveTowards(transform.position,targetPosition,speed * Time.deltaTime);
        }
    }

     private void OnTriggerEnter2D(Collider2D collision) {
         Debug.Log("TE DISPARO BALAS A:"+collision.tag);
        if(collision.tag == "Player"){
            playerScript.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
