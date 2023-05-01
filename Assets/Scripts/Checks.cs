using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checks : MonoBehaviour
{

    public List<GameObject> checks;
    public Sprite box;
    public Sprite good;
    public Sprite bad;
    public List<GameObject> dayEndBox;
    public GameObject dayEnd;
    private int number;

    // Start is called before the first frame update
    void Start()
    {
        number = 0;
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject check in checks)
        {
            if(PlayerPrefs.GetInt("Weekday") <= 4)
            {
                if(tag == "Morning" && check.GetComponent<SpriteRenderer>().sprite == box)
                {
                    if(PlayerPrefs.GetInt("Time") >= 4)
                    {
                        check.GetComponent<SpriteRenderer>().sprite = bad;
                    }
                }
                if (tag == "Night" && check.GetComponent<SpriteRenderer>().sprite == box)
                {
                    if (PlayerPrefs.GetInt("Time") >= 8)
                    {
                        check.GetComponent<SpriteRenderer>().sprite = bad;
                    }
                }
            }
            if (PlayerPrefs.GetInt("Weekday") >= 5)
            {
                if (tag == "Morning" && check.GetComponent<SpriteRenderer>().sprite == box)
                {
                    if (PlayerPrefs.GetInt("Time") >= 5)
                    {
                        check.GetComponent<SpriteRenderer>().sprite = bad;
                    }
                }
                if (tag == "Night" && check.GetComponent<SpriteRenderer>().sprite == box)
                {
                    if (PlayerPrefs.GetInt("Time") >= 8)
                    {
                        check.GetComponent<SpriteRenderer>().sprite = bad;
                    }
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
        dayEnd.SetActive(true);
    }
}
