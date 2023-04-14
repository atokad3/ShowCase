 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int day;
    public int time;
    public TextMeshProUGUI dayText;
    public GameObject clock;
    public List<string> weekdays;
    public List<GameObject> rooms;
    public GameObject button;
    public EnergyBar energyBar;
    public int maxEnergy = 100;
    public int currentEnergy;


    // Start is called before the first frame update
    void Start()
    {
        currentEnergy = maxEnergy;
        energyBar.SetMaxEnergy(maxEnergy);
        LoadDay();
        LoadRoom();
    }

    // Update is called once per frame
    void Update()
    {
       clock.transform.eulerAngles = new Vector3(0, 0, time);
       dayText.text = weekdays[day];
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

    private void LoseEnergy(int energyLoss)
    {
        currentEnergy -= energyLoss;
        energyBar.SetEnergy(currentEnergy);
    }

    public void ChangeDay()
    {
        day += 1;
        PlayerPrefs.SetInt("Weekday", day);
     
    }

    private void LoadRoom()
    {
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
            time = -45;
        }
    }
}
