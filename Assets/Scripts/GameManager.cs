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
    public GameObject button;
    public EnergyBar energyBar;
    public int maxEnergy = 100;
    public int currentEnergy;
    

    // Start is called before the first frame update
    void Start()
    {
        currentEnergy = maxEnergy;
        energyBar.SetMaxEnergy(maxEnergy);
        time = -45;
        LoadDay();
    }

    // Update is called once per frame
    void Update()
    {
        clock.transform.eulerAngles = new Vector3(0, 0, time);
       dayText.text = weekdays[day];
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
