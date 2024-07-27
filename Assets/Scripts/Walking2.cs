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
private bool Moving;
private Rigidbody2D _rigidbody2D;
private Animator _anim;
private SpriteRenderer _spriteRenderer;


void Awake()//oyun motoru açılınca çalışan
{
    _anim = GetComponent<Animator>(); //caching animator
}
void Start()//motor başladıktan sonra tanımladıklarımız
{
    _rigidbody2D = GetComponent<Rigidbody2D>(); //caching rigidbody
    _spriteRenderer = GetComponent<SpriteRenderer>();//sprite renderer
}
private void FixedUpdate()//sabit çalışanlar
{
if (_rigidbody2D.velocity != Vector2.zero)
{
    Moving = true;
}    
else
{
    Moving = false;
}
_rigidbody2D.velocity = new Vector2(speed * moveDirection, _rigidbody2D.velocity.y);

if (Jump == true)
{
    _rigidbody2D.velocity = new Vector2 (_rigidbody2D.velocity.x, jumpForce);
    Jump = false;
}
}

private void Update()//düzenli tekrarladıklarımız
{//Grounded == true &&
    if ( (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
    {
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection = -1.0f;
            _spriteRenderer.flipX = true;
            _anim.SetFloat("Speed", speed);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            moveDirection = 1.0f;
            _spriteRenderer.flipX=false;
            _anim.SetFloat("Speed", speed);
        }
    }
    else if (Grounded == true)
    {
        moveDirection = 0.0f;
        _anim.SetFloat("Speed", 0.0f);
    }

    if (Grounded == true && Input.GetKey(KeyCode.W))
    {
        Jump = true;
        Grounded = false;
        _anim.SetTrigger("Jump");
    }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Zemin"))
        {
            _anim.SetBool("Grounded", true);
            Grounded = true;         
        } }
}
