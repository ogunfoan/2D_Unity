using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    private Scene _scene; //sahne tanımlıyoruz

    private void Awake()
    {
        _scene = SceneManager.GetActiveScene(); //scene managerdan aktif scenei alıyoruz
    }
    private void OnTriggerEnter2D(Collider2D other) //player ile temas edersen seviyeyi yeniden başlat
    {
        if (other.gameObject.CompareTag("Player")) //temas ettiği objenin tagını kontrol ediyor
        {
            SceneManager.LoadScene(_scene.name); // hangi sahneyi yükleyeceğini seçiyoruz
        }
    }
}
