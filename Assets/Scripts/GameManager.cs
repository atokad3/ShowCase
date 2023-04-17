 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    // energy
    public EnergyBar energyBar;
    private float maxEnergy;
    private float currentEnergy;

    // day & time
    private int day;
    public int time;
    public TextMeshProUGUI dayText;
    public TextMeshProUGUI timeText;
    public GameObject clock;
    public List<string> weekdays;
    public List<string> displayTimes;
    public List<float> timeRot;

    public List<GameObject> rooms;
    public GameObject morning;
    public GameObject night;
    public Button closet;
    public Button car;


    // Start is called before the first frame update
    void Start()
    {
        LoadDay();
        LoadRoom();
        HowMuchEnergy();
    }

    // Update is called once per frame
    void Update()
    {
       TimeTasks();
       // changes clock to match day & time
       clock.transform.eulerAngles = new Vector3(0, 0, timeRot[time]);
       dayText.text = weekdays[day];
       timeText.text = displayTimes[time];
       // checks which room player is in and saves if room is active or not
       foreach (GameObject room in rooms)
        {
            if (room.activeInHierarchy)
            {
                PlayerPrefs.SetInt(room.name, 1);
            }
            else if (!room.activeInHierarchy)
            {
                PlayerPrefs.SetInt(room.name, 0);
            }
        }
    }

    public void ChangeDay()
    {
        // changes and saves what day it is
        day += 1;
        PlayerPrefs.SetInt("Weekday", day);
    }

    private void TimeTasks()
    {
        //activates tasks and button based on time of day
        if (time <= 3)
        {
            morning.SetActive(true);
            night.SetActive(false);
            closet.interactable = false;
            car.interactable = true;
        }
        else if (time >= 4)
        {
            morning.SetActive(false);
            night.SetActive(true);
            closet.interactable = false;
            car.interactable = false;
        }
    }

    private void LoadRoom()
    {
        // loads which room player was in when game was last played
        foreach(GameObject room in rooms)
        {
            if (PlayerPrefs.HasKey(room.name) && PlayerPrefs.GetInt(room.name) == 1)
            {
                room.SetActive(true);
            }
            else if(PlayerPrefs.GetInt(room.name) == 0)
            {
                room.SetActive(false);
            }
        }
    }

    private void HowMuchEnergy()
    {
        // changes max energy based on day of week & sets energy bar stats
        if (day == 0)
        {
            maxEnergy = 100;
        }
        else if (day == 1)
        {
            maxEnergy = 95;
        }
        else if (day == 2)
        {
            maxEnergy = 90;
        }
        else if (day == 3)
        {
            maxEnergy = 75;
        }
        else if (day == 4)
        {
            maxEnergy = 45;
        }
        else if (day == 5)
        {
            maxEnergy = 15;
        }
        else if (day == 6)
        {
            maxEnergy = 0;
        }
        PlayerPrefs.SetFloat("MaxEnergy", maxEnergy);
        energyBar.SetMaxEnergy(maxEnergy);
        if (PlayerPrefs.HasKey("CurrentEnergy"))
        {
            currentEnergy = PlayerPrefs.GetFloat("CurrentEnergy");
        }
        else
        {
            currentEnergy = maxEnergy;
        }
    }

    public void LoadDay()
    {
        // load day of week
        if (PlayerPrefs.HasKey("Weekday"))
        {
            day = PlayerPrefs.GetInt("Weekday");
        }
        else if (!PlayerPrefs.HasKey("Weekday"))
        {
            day = 0;
        }
        // load time of day
        if (PlayerPrefs.HasKey("Time"))
        {
            time = PlayerPrefs.GetInt("Time");
        }
        else if (!PlayerPrefs.HasKey("Time"))
        {
            time = 0;
        }
        // if after sunday then gameover
        if (day == 7)
        {
            Debug.Log("yoyoyo");
            SceneManager.LoadScene(sceneBuildIndex: 4);
        }
    }
}
