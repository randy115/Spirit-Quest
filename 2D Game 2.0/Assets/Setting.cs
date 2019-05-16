using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Setting : MonoBehaviour
{
    public int on_or_off;
    // Start is called before the first frame update
    void Start()
    {
        on_or_off = PlayerPrefs.GetInt("settings");
        if(on_or_off == 0)
        {
            AudioListener.pause = true;
        }
        else
        {
            AudioListener.pause = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void _clicker()
    {
        AudioListener.pause = !AudioListener.pause;
        if(AudioListener.pause == false)
        {
            on_or_off = 1;
        }
        else
        {
            on_or_off = 0;
        }

    }
    public void _back()
    {
        PlayerPrefs.SetInt("settings", on_or_off);
        SceneManager.LoadScene(0);
    }
}
