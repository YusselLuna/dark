using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public int damage;
    public GameObject explosion;
    public GameObject soundObject;
   
    // Start is called before the first frame update
    void Start()
    {
       Invoke("DestroyProjectile",lifeTime);
       Instantiate(soundObject,transform.position,transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void DestroyProjectile(){
        Instantiate(explosion,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }

     private void OnTriggerEnter2D(Collider2D collision) {
         Debug.Log("enviando disparo a:"+collision.tag );
        if(collision.tag == "Enemy"){
            Debug.Log("COLISION! "+damage);
            collision.GetComponent<Enemy>().TakeDamage(damage);
            DestroyProjectile();
        }
           if(collision.tag == "boss"){
              Debug.Log("COLISION-BOSS! "+damage);
            collision.GetComponent<Boss>().TakeDamage(damage);
            DestroyProjectile();
        }
    }
}
