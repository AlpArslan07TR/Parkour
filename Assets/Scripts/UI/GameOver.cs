using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void restart_bt()
    {
        SceneManager.LoadScene("MainLevel");
    }

    public void Mainmenu_btn()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ext_bt()
    {
        Application.Quit();
    }
}
