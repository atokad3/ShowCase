using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Checks : MonoBehaviour
{

    public List<GameObject> checks;
    public Sprite box;
    public Sprite good;
    public Sprite bad;
    public List<GameObject> dayEndBox;
    public GameObject dayEnd;
    private int number;
    public GameObject lunchdate;
    private int tasksAreDone;
    public TextMeshProUGUI FinishedTasksText;
    private int time;

    // Start is called before the first frame update
    void Start()
    {
        number = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.HasKey("task10") && SceneManager.GetActiveScene().name == "Game")
        {
            checks[4].GetComponent<SpriteRenderer>().sprite = good;
        }
        if (lunchdate.GetComponent<Interactables>().taskIsDone)
        {
            checks[5].GetComponent<SpriteRenderer>().sprite = good;
        }
        time = gameObject.GetComponent<GameManager>().time;
        ChecksThroughDay();
    }

    public void ChecksThroughDay()
    {
        foreach (GameObject tasker in checks)
        {
            if(tasker.tag == "Morning" && time >= 3)
            {
                if(tasker.GetComponent<SpriteRenderer>().sprite == box)
                {
                    tasker.GetComponent<SpriteRenderer>().sprite = bad;
                }
            }
            if (tasker.tag == "Night" && time >= 8)
            {
                if (tasker.GetComponent<SpriteRenderer>().sprite == box)
                {
                    tasker.GetComponent<SpriteRenderer>().sprite = bad;
                }
            }
            if (tasker.tag == "Lunch" && time >= 4)
            {
                if (tasker.GetComponent<SpriteRenderer>().sprite == box)
                {
                    tasker.GetComponent<SpriteRenderer>().sprite = bad;
                }
            }
        }
    }

    public void EndOfDays()
    {
        foreach (GameObject task in checks)
        {
            if (task.GetComponent<SpriteRenderer>().sprite == good)
            {
                dayEndBox[number].GetComponent<SpriteRenderer>().sprite = good;
            }
            else if (task.GetComponent<SpriteRenderer>().sprite == bad)
            {
                dayEndBox[number].GetComponent<SpriteRenderer>().sprite = bad;
            }
            else if (task.GetComponent<SpriteRenderer>().sprite == box)
            {
                dayEndBox[number].GetComponent<SpriteRenderer>().sprite = bad;
            }
            number++;
        }
        foreach (GameObject tasked in checks)
        {
            if (tasked.GetComponent<SpriteRenderer>().sprite == good)
            {
                tasksAreDone++;
            }
        }
        FinishedTasksText.text = tasksAreDone + "/10 Tasks Done";
        dayEnd.SetActive(true);
    }
}
