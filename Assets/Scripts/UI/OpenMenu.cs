using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenMenu : MonoBehaviour
{
    public GameObject Open_menu;
    public GameObject Close_menu;

    public void Open()
    {
        Open_menu.SetActive(true);
        Close_menu.SetActive(false); 
    }
}
