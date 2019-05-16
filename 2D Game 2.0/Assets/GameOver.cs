using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    public void Start()
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
    }
    public void Retry()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        SceneManager.LoadScene(0);
    }
    public void High()
    {
        SceneManager.LoadScene(3);
    }
}
