using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private bool player_alive = true;
    public GameObject death_effect;
    public GameObject Hand;
    public GameObject crosshair;
    public GameObject gameovermenu;
    
    public Pause pm;

    public void Death()
    {
        if (player_alive)
        {
            player_alive = false;

            //Pause
            pm.isGameOver = true;
            
            //Particle Effect
            Instantiate(death_effect, transform.position, Quaternion.identity);
            //Destroy(transform.gameObject);

            GetComponent<PlayerMovement>().enabled = false;
            Hand.SetActive(false);
            crosshair.SetActive(false);

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            //GameOver Menu
            gameovermenu.SetActive(true);


            
            
        }
    }
    
}
