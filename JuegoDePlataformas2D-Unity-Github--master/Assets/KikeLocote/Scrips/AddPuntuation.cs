using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPuntuation : MonoBehaviour
{
   
  public float puntuacionValue=10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FindObjectOfType<KikeLocoteManager>().AddPuntuacion(puntuacionValue);

        }
        
    }
 
}
