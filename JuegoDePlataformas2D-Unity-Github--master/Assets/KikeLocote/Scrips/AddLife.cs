using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AddLife : MonoBehaviour
{
    
    //creamos variable para audio
    public AudioSource clip;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.transform.CompareTag("Player"))
        {
            
            //activamos el audio            
            collision.transform.GetComponent<PlayerRespawn>().PlayerAddLife();
            
            Destroy(gameObject);

            
            //evitamos el can not play a disabled audio source
            clip.enabled = true;

            clip.Play(); 
            
            
        }

        
    }
}
