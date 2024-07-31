using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private Scene _Scene; //caching

    private void Awake() //sahne açıldığı anda 
    {
        _Scene = SceneManager.GetActiveScene(); //bana aktif sahnenin adını getir ve _scene e eşitle
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) // player tag li bir obje dokunursa
        {
            SceneManager.LoadScene(_Scene.buildIndex+1); //aktif sahnenin indexini bul, ona bir ekle ve sonraki sahneye geçsin
        }
    }

    public int sceneNum;
    public void nextLevel()
    {
        SceneManager.LoadScene(sceneNum);
    }

    public void firstLevel()
    {
        SceneManager.LoadScene(0);
        //SceneManager.LoadScene(_Scene.buildIndex -4);
    }
}
