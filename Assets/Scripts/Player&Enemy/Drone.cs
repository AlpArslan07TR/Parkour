using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    private Transform Player;
    public float speed = 1f;
    public float follow_distance = 10f;

    private float cooldown = 2f;
    public GameObject mesh;

    public GameObject bullet;
    public float health = 100f;
    public GameObject death_effect;

    public AudioClip death_sound;
    



    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    private void Update()
    {
        FollowPlayer();
        Shot();
        Death();
    }

    private void FollowPlayer()
    {

        //Look Player
        transform.LookAt(Player.position);
        transform.rotation *= Quaternion.Euler(new Vector3(0, 0, 0));

        //Move Player
        if (Vector3.Distance(transform.position, Player.position) >= follow_distance)
        {
            transform.Translate(transform.forward * Time.deltaTime * speed);
        }
        else
        {
            transform.RotateAround(Player.position, transform.up, Time.deltaTime * speed*Random.Range(0.2f,3f)); 
        }
        
       
    }

    private void Shot()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
        else
        {
            cooldown = 2f;
            //Shot
            mesh.GetComponent<Animator>().SetTrigger("Shot");
            Instantiate(bullet, transform.position, transform.rotation*Quaternion.Euler(new Vector3(0,180,0)));
        }
        

    }
    private void Death()
    {
        //Spawn Particle 
        
        if (health <= 0)
        {
            
            Destroy(this.gameObject);
            Instantiate(death_effect, transform.position, Quaternion.identity);
           
            GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().PlayOneShot(death_sound);
        }
    }
       
}
