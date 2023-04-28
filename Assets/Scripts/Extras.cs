using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Extras : MonoBehaviour
{

    public TextMeshProUGUI startButton;
    public GameObject menu;
    public GameObject extra;
    public GameObject date;
    public GameObject lockedDate;
    public GameObject exitDate;
    public GameObject taco;
    public int timeTacoToggle; // 0 = no time taco 4 u; 1 = time taco from game; -1 = time taco from extras button

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("TacoToggle", 0); // we are not in time taco so it doesn't exist
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
            taco.SetActive(false);
        }
    }

    public void TimeTacos()
    {
        SceneManager.LoadScene("TimeTaco");
        PlayerPrefs.SetInt("TacoToggle", -1);
        // use player prefs to check if we are entering time taco from the game or from the extras button
    }

    public void ExitDate()
    {
        date.transform.localScale = new Vector3(0.25f, 0.25f, 1);
        date.transform.position = new Vector3(4, 0, 0);
        exitDate.SetActive(false);
        taco.SetActive(true);
    }
}
