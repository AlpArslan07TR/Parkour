using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSC : MonoBehaviour
{
    public void play_btn()
    {
        SceneManager.LoadScene("MainLevel");
    }

    public void exit_btn()
    {
        Application.Quit();
    }
}
