using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Weapon weaponToEquip;
    public GameObject effect;
    public GameObject soundObject;

   private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Player"){
            Instantiate(effect,transform.position,Quaternion.identity);
            Instantiate(soundObject,transform.position,transform.rotation);
            collision.GetComponent<Player>().ChangeWeapon(weaponToEquip);
            Destroy(gameObject);
        }
    }
 
}
