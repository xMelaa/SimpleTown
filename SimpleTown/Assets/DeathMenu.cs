using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour{
    public static bool GameIsPaused = false;
    public GameObject deathMenuUI;
    public PlayerMovement player;    
    
    void Start(){
        player = FindObjectOfType<PlayerMovement> ();
    }

    void Update(){
        if (player.energia < 1){
            deathMenuUI.SetActive(true);
            Time.timeScale = 0f;
            //GameIsPaused = true;
        }
    }

    public void LoadMenu(){
        player.energia = 1;
        SceneManager.LoadScene(0); //scena 0 = menu
        Time.timeScale = 1f;        
    }

    public void ResetLevel(){   
        player.energia = 1;           
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //zaladuj aktualny lvl  
        Time.timeScale = 1f;
    }
}
