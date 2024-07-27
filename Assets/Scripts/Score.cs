using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private AudioSource _audio; //ses kaynağını tanımlıyoruz.

    private void Awake() // sistem ayağa kalktığında yapılacaklar
    {
        _audio = GetComponent<AudioSource>(); //audioSource dan gelen sesi al
    }

    private void OnTriggerEnter2D(Collider2D other) // bizim objemiz başka bir objeyle dokundukları anda
    {
        if (other.gameObject.CompareTag("muz")) //tagı kıyasla, eğer uyuyorsa
        {
            _audio.Play(); // olduğunda da sesi çal
            Destroy(other.gameObject); //öbür objeyi yok et
            TScore++; //puanı arttır
            
        }
    }
    
}
