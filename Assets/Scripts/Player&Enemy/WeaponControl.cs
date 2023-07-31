using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControl : MonoBehaviour
{

    public GameObject Hand;
    public LayerMask obstacle_Layer;
    public Vector3 offset;
    public GameObject bullet;
    public Transform firepoint;

    private float cooldown;
    public AudioClip gunshot;

    RaycastHit Hit;
    private void Update()
    {

        //Look
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out Hit, Mathf.Infinity, obstacle_Layer))
        {
            Hand.transform.LookAt(Hit.point);
            Hand.transform.rotation *= Quaternion.Euler(offset);
        }

        //Cooldown
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }

        //Shot
        if (Input.GetMouseButtonDown(0)&&cooldown<=0)
        {
            //Create Bullet
            Instantiate(bullet, transform.position, transform.rotation * Quaternion.Euler(90, 0, 0));
            //Reset Cooldown
            cooldown = 0.25f;

            //Sound
            GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().PlayOneShot(gunshot);

            //Animation
            GetComponent<Animator>().SetTrigger("shot");
        }
    }
}
