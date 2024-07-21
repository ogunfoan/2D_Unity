using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Walking2 : MonoBehaviour
{
public float moveDirection;
public float jumpForce;
public float speed = 1.0f;
private bool Jump;
private bool Grounded = true;
private bool moving;
private Rigidbody2D rb;
private Animator anim;
private SpriteRenderer spriteRenderer;


void Awake()//oyun motoru açılınca çalışan
{
    anim = GetComponent<Animator>(); //caching animator

    
}
void Start()//motor başladıktan sonra tanımladıklarımız
{
    rb = GetComponent<Rigidbody2D>(); //caching rigidbody
    spriteRenderer = GetComponent<SpriteRenderer>();
}
private void FixedUpdate()//sabit çalışanlar
{
if (rb.velocity != Vector2.zero)
{
    moving = true;
}    
else
{
    moving = false;
}
rb.velocity = new Vector2(speed * moveDirection, rb.velocity.y);

if (Jump == true)
{
    rb.velocity = new Vector2 (rb.velocity.x, jumpForce);
    Jump = false;
}
}

private void Update()//düzenli tekrarladıklarımız
{
    if (Grounded == true && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
    {
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection = -1.0f;
            spriteRenderer.flipX = true;
            anim.SetFloat("Speed", speed);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            moveDirection = 1.0f;
            spriteRenderer.flipX=false;
            anim.SetFloat("Speed", speed);
        }
    }
    else if (Grounded == true)
    {
        moveDirection = 0.0f;
        anim.SetFloat("Speed", 0.0f);
    }

    if (Grounded == true && Input.GetKey(KeyCode.W))
    {
        Jump = true;
        Grounded = false;
        anim.SetTrigger("Jump");
    }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Zemin"))
        {
            anim.SetBool("Grounded", true);
            Grounded = true;         
        } }
}
