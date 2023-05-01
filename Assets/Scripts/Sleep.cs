using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sleep : Interactables
{
    public List<GameObject> tasks;
    public List<GameObject> doors;
    public List<GameObject> dayEndBox;
    public GameObject dayEnd;
    private GameObject gameManager;
    private int number;
    public bool dayIsDone;

    void Start()
    {
        gameManager = GameObject.Find("Main Camera");
        dayIsDone = false;
        number = 0;
    }

    void Update()
    {
        DayEnds();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!taskIsDone)
        {
            glow.SetActive(true);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        glow.SetActive(false);
    }

    private void ResetStuff()
    {
        PlayerPrefs.DeleteKey("StopX");
        PlayerPrefs.DeleteKey("StopY");
        PlayerPrefs.DeleteKey("StopCamX");
        PlayerPrefs.DeleteKey("StopCamY");
        PlayerPrefs.DeleteKey("CurrentEnergy");
        PlayerPrefs.SetInt("Time", 0);
        foreach(GameObject task in tasks)
        {
            // resets all tasks
            task.GetComponent<Interactables>().DayChangeTask();
        }
        foreach(GameObject door in doors)
        {
            door.GetComponent<Daytime>().ResetBool();
        }
    }

    private void DayEnds()
    {
        if (Input.GetKeyDown(KeyCode.E) && glow.activeInHierarchy && !taskIsDone)
        {
            foreach (GameObject endTask in tasks)
            {
                    if (endTask.GetComponent<Interactables>().taskIsDone)
                    {
                        dayEndBox[number].GetComponent<SpriteRenderer>().sprite = check;
                    }
                    else if (!endTask.GetComponent<Interactables>().taskIsDone)
                    {
                        dayEndBox[number].GetComponent<SpriteRenderer>().sprite = bad;
                    }
                number++;
            }
            if (gameManager.GetComponent<GameManager>().isSchoolDone)
            {
                box.GetComponent<SpriteRenderer>().sprite = check;
            }
            else if (!gameManager.GetComponent<GameManager>().isSchoolDone)
            {
                box.GetComponent<SpriteRenderer>().sprite = bad;
            }
            dayIsDone = true;
            dayEnd.SetActive(true);
        }
        if (dayIsDone && Input.GetMouseButtonDown(0))
        {
            // resets player & camera pos and goes to next day
            ResetStuff();
            gameManager.GetComponent<GameManager>().ChangeDay();
            SceneManager.LoadScene("Game");
        }
    }
}
