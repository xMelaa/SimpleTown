using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pocisk : MonoBehaviour
{
   private void OnCollisionEnter(Collision collision){        
        if (collision.gameObject.tag == "Destroy"){            
            Destroy(collision.gameObject); // Usuwanie enemy/fence przy kolizji
        }        
        Destroy(gameObject); // Usuwanie bulleta przy kolizji
        
    }
    void Update(){
        Destroy(gameObject, 1f); //usuwanie pocisku po 1s
    }
    
}
