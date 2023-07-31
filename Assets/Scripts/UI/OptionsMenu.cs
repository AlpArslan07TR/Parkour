using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class OptionsMenu : MonoBehaviour
{

    public AudioMixer audiomix;
    private bool isFullScreen = true;

    public void SetResoulation(int index)
    {
        if (index == 0)
        {
            Screen.SetResolution(1920, 1080,isFullScreen);
        }else if(index == 1)
        {
            Screen.SetResolution(1680, 1050, isFullScreen);
        }else if(index == 2)
        {
            Screen.SetResolution(1600, 1024, isFullScreen);
        }
        else if (index == 3)
        {
            Screen.SetResolution(1280, 1024, isFullScreen);
        }
        else if (index == 4)
        {
            Screen.SetResolution(1280, 1060, isFullScreen);
        }
        else if (index == 5)
        {
            Screen.SetResolution(800, 600, isFullScreen);
        }
    }

    public void SetQuality(int quailtyIndex)
    {
        QualitySettings.SetQualityLevel(quailtyIndex);


    }

    public void SetFullScreen(bool Fullscreen_enable)
    {
        Screen.fullScreen = Fullscreen_enable;
        isFullScreen = Fullscreen_enable;
    }

    public void SetMouseSensitivity(float value)
    {
        PlayerPrefs.SetFloat("MouseSensitivity", value);
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().mousesens = value;
        }
    }

    public void SetMasterVolume(float value)
    {
        audiomix.SetFloat("MasterVolume",value);
    }

    public void SetMusicVolume(float value)
    {
        audiomix.SetFloat("MusicVolume", value);
    }
}
