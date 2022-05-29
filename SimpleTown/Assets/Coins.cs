using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Coins : MonoBehaviour
{
    public PlayerMovement player;      
    public bool teleport = false;    
        //Aktualna ilość punktów
    private int coin = 0;
    private int coinLVL = 0;
    public int lvlNumber = 0;
        //Pobieramy muzykę do coinSound
    public AudioClip coinSound;
        //Głośność muzyki
    public float volume;
    public TextMeshProUGUI textCoins;
    
   
 
    void Start(){
        player = FindObjectOfType<PlayerMovement> (); //automatycznie przypisz obiekt        
        lvlNumber = SceneManager.GetActiveScene().buildIndex;

        switch (lvlNumber)
                {
                   case 0:
                        coinLVL = 5;
                        break;
                    /*  case 1:
                        coinLVL = 5;
                        break;
                  case 2:
                        coinLVL = 12;
                        break;
                    case 3:
                        coinLVL = 56;
                        break; */
                    default:
                        break;
                }
                textCoins.text = coin.ToString() + " / " + coinLVL;

                 //ilosc pkt do zdonycia na konkretnych lvl TO DO

    }   

    void OnTriggerEnter(Collider col){ //jesli wejdzie na pole    
        if(col.tag== "Coins"){ //jesli colider ma tag coins         
           Destroy(col.gameObject);           
        }

        switch (lvlNumber){
                    case 1:
                        coinLVL = 5;
                        break;
                   /* case 2:
                        coinLVL = 12;
                        break;
                    case 3:
                        coinLVL = 56;
                        break;  */                  
                    default:
                        break;
                } 

            if (col.gameObject.tag == "Coins"){                
                coin++; //powiększ coin o 1 

                if(coin==coinLVL){ //jeśli osiągniemy ilość punktów do przejścia na kolejny poziom to odblokuj teleport
                    teleport = true;                    
                }

                textCoins.text = coin.ToString() + " / " + coinLVL;//zmien wczesniej wybrany TextMeshPro na Tekst + ilość punktów zamienionych na string        

                Vector3 colPosition = col.transform.position; //tworzymy Vector3 z miejscem kolizji                  
                
                AudioSource.PlayClipAtPoint(coinSound, colPosition, volume); //Odtwórz dźwięk coinSound w miejscu kolizji
                    //Zniszcz obiekt
                //Destroy(gameObject);
            }
    } 
}    
