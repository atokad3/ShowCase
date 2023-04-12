 using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Daytime : MonoBehaviour
{
    private int time;
    public int setTime;
    private GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        time = gameManager.GetComponent<GameManager>().time;
    }

    //make a thing that has time go up once you leave the house, days are like levels like cat game need to clear objectives to get to next day
    public void ClockTimer()
    {
        gameManager.GetComponent<GameManager>().time = setTime; // once you leave the house and click on the door the time gets set to 8 am\
                        // set the time on the button need to search for answers = input field on button for time
        PlayerPrefs.SetInt("Time", time);
    }

}
