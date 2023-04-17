 using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Daytime : MonoBehaviour
{
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
            PlayerPrefs.SetInt("Time", gameManager.GetComponent<GameManager>().time);
            timeChanged = true;
            PlayerPrefs.SetInt("Door" + doorNum, 1);
        }
    }

}
