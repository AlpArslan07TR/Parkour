using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    private bool isGamePaused;

    public GameObject PauseMenu;
    public GameObject d_crosshair;
    public GameObject player, weapon;
    public AudioSource music;


    public bool isGameOver = false;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)&&!isGameOver)
        {
            if (!isGamePaused)
            {
                PauseGame();
            }
            else
            {
                Resume();
            }
        }
    }

    private void PauseGame()
    {
        music.Pause();
        player.GetComponent<PlayerMovement>().enabled = false;
        weapon.GetComponent<WeaponControl>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        d_crosshair.SetActive(false);
        Time.timeScale = 0;
        PauseMenu.SetActive(true);
        isGamePaused = true;
    }

    private void Resume()
    {
        music.UnPause();
        player.GetComponent<PlayerMovement>().enabled = true;
        weapon.GetComponent<WeaponControl>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        d_crosshair.SetActive(true);
        Time.timeScale = 1;
        PauseMenu.SetActive(false);
        isGamePaused = false;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
