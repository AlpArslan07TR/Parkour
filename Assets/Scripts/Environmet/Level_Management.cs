using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Management : MonoBehaviour
{
    //Player Enter - Player Exit
    public bool player_enter, player_exit;
    
    //Drone Spawn
    private bool spawned;

    public Transform[] drone_spawners;
    public GameObject drone;
    
    //Level
    public GameObject level;
    public GameObject destroy_level;
    

    private void Awake()
    {
        player_enter = false;
        spawned = false;
    }


    private void Update()
    { 
        //Drone Spawn
        if (!spawned)
        {
            if (player_enter)
            {
                for(int i= 0; i< drone_spawners.Length; i++)
                {
                    Instantiate(drone, drone_spawners[i].position, Quaternion.identity);
                    
                }

                //Bool
                spawned = true;

                //Level Spawn
                SpawnLevel();


                
            }
            
        }
        if (player_exit)
        {
            
            if(destroy_level != null)
            Destroy(destroy_level);
            
        }
    }

    private void SpawnLevel()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z - 171);
        GameObject obj= Instantiate(level, pos, Quaternion.identity);
        obj.GetComponent<Level_Management>().destroy_level = this.gameObject;
        
    }

}
