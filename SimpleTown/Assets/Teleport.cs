using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour{
    public PlayerMovement player;
    public Coins coins;
    public string nextLvl;
    
    void Start(){
        player = FindObjectOfType<PlayerMovement> (); //automatycznie przypisz obiekt
        coins = FindObjectOfType<Coins> ();
    }

    void OnTriggerEnter(Collider col){ //jesli wejdzie na pole    
        if(col.name == "Player" && coins.teleport){ //jesli colider to player i teleport jest true 
           //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);  
           SceneManager.LoadScene(nextLvl);          
        }
    }    
}