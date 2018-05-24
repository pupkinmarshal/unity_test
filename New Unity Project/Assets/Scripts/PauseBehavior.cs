using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseBehavior : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    //public GameObject MobileControls;
     public void Resume()
    {
        //gameObject.SetActive(false);
        PauseMenuUI.SetActive(false);
       // MobileControls.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
        GameObject.Find("LevelMusic").GetComponent<AudioSource>().volume = 1;
    }

    public void Pause()
    {
        PauseMenuUI.SetActive(true);
       // MobileControls.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
        GameObject.Find("LevelMusic").GetComponent<AudioSource>().volume = 0.2f;
    }
    public void Quit()
    {
        Application.Quit();
    }

        // Update is called once per frame
        void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
                Resume();
            else
                Pause();
        }
    }
}
