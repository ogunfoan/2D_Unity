using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _yazialani;
    private AudioSource _audio; //ses kaynağını tanımlıyoruz.

    private void Awake() // sistem ayağa kalktığında yapılacaklar
    {
        _audio = GetComponent<AudioSource>(); //audioSource dan gelen sesi al
        _yazialani.text = TotalScore.Tscore.ToString();
    }

    private void OnTriggerEnter2D(Collider2D other) // bizim objemiz başka bir objeyle dokundukları anda
    {
        if (other.gameObject.CompareTag("muz")) //tagı kıyasla, eğer uyuyorsa
        {
            _audio.Play(); // olduğunda da sesi çal
            Destroy(other.gameObject); //öbür objeyi yok et
            TotalScore.Tscore++; //puanı arttır
            _yazialani.text = TotalScore.Tscore.ToString();

        }
    }
    
}
