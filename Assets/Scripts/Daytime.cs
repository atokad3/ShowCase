 using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Daytime : MonoBehaviour
{
    private int time;
    public int setTime;
    public float doorNum;
    private GameObject gameManager;
    public bool timeChanged;

    void Start()
    {
        gameManager = GameObject.Find("Main Camera");

    }


    void Update()
    {
        time = gameManager.GetComponent<GameManager>().time;
        if(PlayerPrefs.GetInt("Door" + doorNum) == 1)
        {
            timeChanged = true;
        }
    }

    public void ResetBool()
    {
        PlayerPrefs.SetInt("Door" + doorNum, 0);
    }


    public void ClockTimer()
    {
        // sets time in game to setTime when button is pressed
        if(timeChanged == false)
        {
            gameManager.GetComponent<GameManager>().time = setTime;
            PlayerPrefs.SetInt("Time", time);
            timeChanged = true;
            PlayerPrefs.SetInt("Door" + doorNum, 1);
        }
    }

}
