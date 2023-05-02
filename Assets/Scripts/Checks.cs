using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        dayEnd.SetActive(true);
    }
}
