using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sleep : Interactables
{
    public List<GameObject> tasks;
    public List<GameObject> doors;
    private GameObject gameManager;

    void Start()
    {
        gameManager = GameObject.Find("Main Camera");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && glow.activeInHierarchy && !taskIsDone)
        {
            // resets player & camera pos and goes to next day
            ResetStuff();
            gameManager.GetComponent<GameManager>().ChangeDay();
            SceneManager.LoadScene("Game");
        }
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
}
