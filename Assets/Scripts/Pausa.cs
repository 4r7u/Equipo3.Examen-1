using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    private bool gameIsPaused;
    [SerializeField] private GameObject pauseMenu;
    private void Update(){
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameIsPaused = !gameIsPaused;
            PauseGame();
        }
    }
    void PauseGame(){
            if (gameIsPaused){
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
            }else{
                Time.timeScale = 1;
                pauseMenu.SetActive(false);
            }
        }
     public void Resume()
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
            Debug.Log("Resume");
        }
        public void Quit()
        {
            SceneManager.LoadScene(0);
        }
}