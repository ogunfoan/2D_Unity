using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Walking : MonoBehaviour
{
    public float Speed =1.0f;
    private Vector3 charPos;
    [SerializeField] private GameObject _camera;
    private Rigidbody2D rb;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {//caching stuff
        _spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        charPos = transform.position;
    }
private void FixedUpdate() {
    
}
    // Update is called once per frame


    void Update()
    { // hesapladığım pozisyon karakterime işlensin 
    charPos = new Vector3(charPos.x + (Input.GetAxis("Horizontal") *Speed*Time.deltaTime) ,charPos.y);
    transform.position = charPos; //pozisyonu atamak için
    //karakterimiz hareketlenmesi için
    if(Input.GetAxis("Horizontal") == 0.0f){
        _animator.SetFloat("Speed", 0.0f);
    }
    else{
        _animator.SetFloat("Speed", 1.0f);
    }

    //kameranın dönmesi için
    if(Input.GetAxis("Horizontal") > 0.01f) {
        _spriteRenderer.flipX = false;
    }
    else if (Input.GetAxis("Horizontal") < -0.01f){
        _spriteRenderer.flipX = true;
    }
    }

    private void LateUpdate() {
    _camera.transform.position = new Vector3(charPos.x,charPos.y, charPos.z-1.0f);
    }
}
