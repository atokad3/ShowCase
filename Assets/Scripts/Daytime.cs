 using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Daytime : MonoBehaviour
{
    private int time;
    public int setTime;
    private GameObject gameManager;

    void Start()
    {
        gameManager = GameObject.Find("Main Camera");
    }


    void Update()
    {
        time = gameManager.GetComponent<GameManager>().time;
    }

 
    public void ClockTimer()
    {
        // sets time in game to setTime when button is pressed
        gameManager.GetComponent<GameManager>().time = setTime;            
        PlayerPrefs.SetInt("Time", time);
    }

}
