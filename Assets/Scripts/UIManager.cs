using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("GameOver")]
    [SerializeField] private GameObject gameOverScreen;

    [Header("Pause")]
    [SerializeField] private GameObject pauseScreen;

    [Header("End")]
    [SerializeField] private GameObject endScreen;

    private void Awake()
    {
        gameOverScreen.SetActive(false);
        pauseScreen.SetActive(false);
        endScreen.SetActive(false);
    }

    public void GameOver()
    {

        gameOverScreen.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainManu()
    {
        SceneManager.LoadScene(0);
        PauseGame(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape)) 
        {
            if (pauseScreen.activeInHierarchy)
                PauseGame(false);
            else
                PauseGame(true);
        }
        /*
        if (Input.GetKey(KeyCode.Q))
        { 
           endScreen.SetActive(true);
        }
        */

    }
    public void PauseGame(bool status)
    {
        pauseScreen.SetActive(status);

        if (status)
            Time.timeScale = 0;
        else 
            Time.timeScale = 1;
    }
}
