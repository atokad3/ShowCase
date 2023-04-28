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
    private TextMeshProUGUI dayText;
    private TextMeshProUGUI timeText;
    private GameObject clock;
    private string[] weekdays = {"Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"};
    private string[] displayTimes = {"7:00", "7:15", "7:45", "8:00", "2:30", "2:45", "6:30", "7:30", "10:00" };
    private float[] timeRot = {-45, -35, -20, -10, 10, 15, 40, 50, 70 };

    public List<GameObject> rooms;
    public GameObject morning;
    public GameObject night;
    public Button closet;
    public GameObject carToSchool;
    public GameObject carToWork;
    private GameObject carInUse;
    private GameObject keys;
    private GameObject player;
    public GameObject roomNight;
    public Button bedroomDoor;
    public GameObject phone;
    public bool isWorkDone;
    public Sprite datePjs;
   


    // Start is called before the first frame update
    void Start()
    {
        SetUp();
        if (day == 5 && PlayerPrefs.HasKey("Date"))
        {
            phone.SetActive(true);
            PlayerPrefs.DeleteKey("Date");
        }
    }

    // Update is called once per frame
    void Update()
    {
       TimeTasks();
       // changes clock to match day & time
       if(day <= 6)
        {
       clock.transform.eulerAngles = new Vector3(0, 0, timeRot[time]);
       dayText.text = weekdays[day];
       timeText.text = displayTimes[time];
        }
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
        if(day == 5 && isWorkDone)
        {
            PlayerPrefs.SetString("Date", "Yes");
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
            if (keys.GetComponent<Interactables>().taskIsDone)
            {
            carInUse.SetActive(true);
            }
            else if (!keys.GetComponent<Interactables>().taskIsDone)
            {
                Debug.Log("Get Keys!!");  
            }
        }
        else if (time >= 4)
        {
            morning.SetActive(false);
            night.SetActive(true);
            closet.interactable = true;
            carInUse.SetActive(false);
        }


        if (time >= 8)
        {
            roomNight.SetActive(true);
            player.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f, 1);
            bedroomDoor.interactable = false;
        }
        else
        {
            bedroomDoor.interactable = true;
        }
    }

    private void SetUp()
    {
        LoadDay();
        LoadRoom();
        HowMuchEnergy();
        carToSchool.SetActive(false);
        carToWork.SetActive(false);
        keys = GameObject.Find("Keys");
        player = GameObject.Find("Player");
        clock = GameObject.Find("clockpt2");
        dayText = GameObject.Find("Days").GetComponent<TextMeshProUGUI>();
        timeText = GameObject.Find("Times").GetComponent<TextMeshProUGUI>();
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

    public void LoseEnergy(int energyLoss)
    {
        // makes tasks cost energy
        currentEnergy = PlayerPrefs.GetFloat("CurrentEnergy");
        currentEnergy -= energyLoss;
        energyBar.SetEnergy(currentEnergy);
        PlayerPrefs.SetFloat("CurrentEnergy", currentEnergy);
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
        else if (day == 4 && !PlayerPrefs.HasKey("FinishGame?"))
        {
            maxEnergy = 45;
        }
        else if (day == 5 && !PlayerPrefs.HasKey("FinishGame?"))
        {
            maxEnergy = 15;
        }
        else if (day == 6 && !PlayerPrefs.HasKey("FinishGame?"))
        {
            maxEnergy = 0;
        }
        else if (day == 4 && PlayerPrefs.HasKey("FinishGame?"))
        {
            maxEnergy = 85;
        }
        else if (day == 5 && PlayerPrefs.HasKey("FinishGame?"))
        {
            maxEnergy = 95;
        }
        else if (day == 6 && PlayerPrefs.HasKey("FinishGame?"))
        {
            maxEnergy = 100;
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
        // does car take to work or school
        if(day >= 5)
        {
            carInUse = carToWork;
        }
        else
        {
            carInUse = carToSchool;
        }
        // if after sunday then gameover
        if (day == 7 && !PlayerPrefs.HasKey("FinishGame?"))
        {
            SceneManager.LoadScene(sceneBuildIndex: 4);
        }
        else if(day == 7 && PlayerPrefs.HasKey("FinishGame?"))
        {
            SceneManager.LoadScene(sceneBuildIndex: 6);
            
        }



       
        // time taco mini game in menu only after you complete the game first time
    }
}
