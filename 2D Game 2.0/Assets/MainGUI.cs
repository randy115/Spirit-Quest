using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainGUI : MonoBehaviour
{
    public GameObject PauseUI;
    public GameObject GameHUD;
    //public PlayerController2D Hero;
    public bool paused;
    void start()
    {
        int on_or_off = PlayerPrefs.GetInt("settings");
        if (on_or_off == 0)
        {
            AudioListener.pause = true;
        }
        else
        {
            AudioListener.pause = false;
        }
        // Hero = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController2D>();
        PauseUI.SetActive(false);
        GameHUD.SetActive(true);
        paused = false;
    }
    void Update()
    {
        if (paused)
        {
            PauseUI.SetActive(true);
            GameHUD.SetActive(false);
            Time.timeScale = 0;
        }
        if (!paused)
        {
            PauseUI.SetActive(false);
            GameHUD.SetActive(true);
            Time.timeScale = 1;
        }
    }
    public void Resume()
    {
        paused = !paused;
    }
    public void Pause()
    {
        paused = !paused;
    }
    public void Quit()
    {
        SceneManager.LoadScene(0);

    }
}
