using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public float speed;
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 moveAmount;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public Animator hurtAnim;
    public int health;
    // Start is called before the first frame update
    void Start()
    {
         anim = GetComponent<Animator>();
         rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput  = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
        moveAmount = moveInput.normalized * speed;
        Debug.Log("MOVE AMOUNT:"+moveAmount);
        Debug.Log("Transform:"+transform.position);
        
        if( moveInput != Vector2.zero){
            anim.SetBool("isRunning",true);
        }else{
            anim.SetBool("isRunning",false);
        }
    }

    private void FixedUpdate(){
        rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime);
    }


       public void TakeDamage(int damageAmount){
        Debug.Log("damageAmount:"+damageAmount);
        health -= damageAmount;
        UpdateHealthUI(health);
        hurtAnim.SetTrigger("hurt");
        if(health <= 0){
            Debug.Log("ya felpo");
            Destroy(gameObject);
        }
    }

    public void ChangeWeapon(Weapon weaponToEquip){
        Destroy(GameObject.FindGameObjectWithTag("Weapon"));      
        Instantiate(weaponToEquip,transform.position,transform.rotation,transform);
    }

    void UpdateHealthUI(int currentHealth){
        for(int i = 0;i < hearts.Length;i++){
            if(i < currentHealth){
                hearts[i].sprite = fullHeart;
            }else{
                hearts[i].sprite = emptyHeart;
            }
        }
    }

    public void Heal(int healAmount){
        if(health + healAmount > 5){
            health = 5;
        }else{
            health += healAmount;
        }
        UpdateHealthUI(health);
    }

}
