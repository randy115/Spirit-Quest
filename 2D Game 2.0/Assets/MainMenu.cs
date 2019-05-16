using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Settings;
    void start()
    {
        Resources.UnloadUnusedAssets();
        int on_or_off = on_or_off = PlayerPrefs.GetInt("settings");
        if (on_or_off == 0)
        {
            AudioListener.pause = true;
        }
        else
        {
            AudioListener.pause = false;
        }
        // Hero = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController2D>();
        Settings.SetActive(false);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void HighScore()
    {
        SceneManager.LoadScene(3);
    }
    public void Settings1()
    {
        SceneManager.LoadScene(4);
    }
}
