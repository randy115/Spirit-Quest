using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class highscore : MonoBehaviour
{
    public Text text1;
    public Text text2;
    public Text text3;
    int[] array = new int[4];

    // Start is called before the first frame update
    void Start()
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
        array[3] = PlayerPrefs.GetInt("Player_Score");
        array[0] = PlayerPrefs.GetInt("p1");
        array[1] = PlayerPrefs.GetInt("p2");
        array[2] = PlayerPrefs.GetInt("p3");
        for(int j = 0; j <= 4 -2; j++)
        {
            for(int i = 0;i <= 4 -2; i++)
            {
                if(array[i] < array[i + 1])
                {
                    int temp = array[i + 1];
                    array[i + 1] = array[i];
                        array[i] = temp;
                }
            }
        }
            
            text1.text = array[0].ToString();
            text2.text = array[1].ToString();
            text3.text = array[2].ToString();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void quit()
    {
        
        PlayerPrefs.SetInt("p1", array[0]);
        PlayerPrefs.SetInt("p2", array[1]);
        PlayerPrefs.SetInt("p3", array[2]);
        SceneManager.LoadScene(0);
    }
    public void reset()
    {
        text1.text = "0";
        text2.text = "0";
        text3.text = "0";
        array[0] = 0;
        array[1] = 0;
        array[2] = 0;

    }
}
