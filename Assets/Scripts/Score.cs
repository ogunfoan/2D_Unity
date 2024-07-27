using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int pointsa=0; 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("muz"))
        {
            Destroy(other.gameObject);
            pointsa++;
        }
    }
    
}
