using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sleep : MonoBehaviour
{

    public GameObject glow;
    public bool taskIsDone;
    public List<GameObject> tasks;
    private GameObject gameManager;

    void Start()
    {
        gameManager = GameObject.Find("Main Camera");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && glow.activeInHierarchy && !taskIsDone)
        {
            foreach(GameObject task in tasks)
            {
                // resets all tasks
                task.GetComponent<Interactables>().DayChangeTask();
            }
            // resets player & camera pos and goes to next day
            PlayerPrefs.DeleteKey("StopX");
            PlayerPrefs.DeleteKey("StopY");
            PlayerPrefs.DeleteKey("StopCamX");
            PlayerPrefs.DeleteKey("StopCamY");
            PlayerPrefs.DeleteKey("CurrentEnergy");
            taskIsDone = true;
            glow.SetActive(false);
            PlayerPrefs.SetInt("Time", 0);
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

}
