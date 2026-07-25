using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    private bool gameRunning = true;
    private void Start()
    {
        pauseMenu.SetActive(false);
        Cursor.visible = false;
    }
    private void Update()
    { 
        if (Input.GetKeyDown(KeyCode.Escape) && gameRunning)
        {
            InputManager.instance.callDisable();
            pauseMenu.SetActive(true);
            gameRunning = !gameRunning;
            print("Game Paused");
        }else if (Input.GetKeyDown(KeyCode.Escape) && !gameRunning)
        {
            InputManager.instance.callEnable();
            pauseMenu.SetActive(false);
            gameRunning = !gameRunning;
        }
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        InputManager.instance.callEnable();
        gameRunning = !gameRunning;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void QuittoMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
