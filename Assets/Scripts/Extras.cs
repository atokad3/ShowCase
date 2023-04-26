using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Extras : MonoBehaviour
{

    public TextMeshProUGUI startButton;
    public GameObject menu;
    public GameObject extra;
    public GameObject date;
    public GameObject lockedDate;
    public GameObject exitDate;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("FinishGame?"))
        {
            lockedDate.SetActive(false);
        }
        else
        {
            lockedDate.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.HasKey("StopX"))
        {
            startButton.text = "Continue";
        }
        else
        {
            startButton.text = "Start";
        }
    }

    public void ExtraMenu()
    {
        if (PlayerPrefs.HasKey("FinishGame?") && menu.activeInHierarchy)
        {
            menu.SetActive(false);
            extra.SetActive(true);
        }
        else if (PlayerPrefs.HasKey("FinishGame?") && !menu.activeInHierarchy)
        {
            menu.SetActive(true);
            extra.SetActive(false);
        }
    }

    public void Date()
    {
        if (PlayerPrefs.HasKey("FinishGame?"))
        {
            date.transform.localScale = new Vector3(1, 1, 1);
            date.transform.position = new Vector3(0, 0, 0);
            lockedDate.SetActive(false);
            exitDate.SetActive(true);
        }
    }

    public void ExitDate()
    {
        date.transform.localScale = new Vector3(0.25f, 0.25f, 1);
        date.transform.position = new Vector3(4, 0, 0);
        exitDate.SetActive(false);
    }
}
