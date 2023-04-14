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

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && glow.activeInHierarchy && !taskIsDone)
        {
            foreach(GameObject task in tasks)
            {
                task.GetComponent<Interactables>().DayChangeTask();
            }
            PlayerPrefs.DeleteKey("StopX");
            PlayerPrefs.DeleteKey("StopY");
            PlayerPrefs.DeleteKey("StopCamX");
            PlayerPrefs.DeleteKey("StopCamY");
            taskIsDone = true;
            glow.SetActive(false);
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
