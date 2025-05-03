using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class pauseMenu : MonoBehaviour
{
    [SerializeField] GameObject PauseMenu;
    public GameObject Cooking;
    public GameObject Mergeback;
    public GameObject Mergeing;
    public void Pause()
    {
        Mergeback.SetActive(true);
        PauseMenu.SetActive(true);
        Time.timeScale = 0;
        Cooking.SetActive(false);
        
        Mergeing.SetActive(false);

    }
   
    public void Resume()
    {
        Mergeback.SetActive(false);
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
        
        Cooking.SetActive(true);
        Mergeing.SetActive(true);   
    }
}
