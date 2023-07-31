using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartUP : MonoBehaviour
{
    public Slider sens_slider;

    private void Awake()
    {
        //MouseSens
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().mousesens = PlayerPrefs.GetFloat("MouseSensitivity", 200);
        sens_slider.value = PlayerPrefs.GetFloat("MouseSensitivity", 200);
    }
}
