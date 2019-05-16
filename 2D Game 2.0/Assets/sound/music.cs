using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music : MonoBehaviour
{
   public AudioSource audioData;
    private int x;
    // Start is called before the first frame update
    void Start()
    {
        x = PlayerPrefs.GetInt("settings");
    }

    // Update is called once per frame
    void Update()
    {
        //if(x == 1)
        //{
        //    audioData.Play();
        //}
        //else
        //{
        //    audioData.Stop();
        //}
       
    }
}
