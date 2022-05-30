using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
   
    void Update()    {
        if (Input.GetKeyDown(KeyCode.Escape)){ //esc odpowiada za pauze w grze
            if(GameIsPaused){
                Resume();
            }
            else {
                PauseMenu();
            }
        }
    }

    public void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void PauseMenu() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu(){
        SceneManager.LoadScene(0); //scena 0 = menu (nr scen do ustawienia w build settings)
        Time.timeScale = 1f;
    }
}
