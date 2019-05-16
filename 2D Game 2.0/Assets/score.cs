using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class score : MonoBehaviour
{
    public PlayerController2D hero;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        hero = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController2D>();

    }

    // Update is called once per frame
    void Update()
    {
        text.text = hero.killreturn().ToString();
    }
}
