using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Extras : MonoBehaviour
{

    private TextMeshProUGUI startButton;
    public GameObject menu;
    public GameObject extra;
    public Button date;
    public GameObject lockedDate;
    public GameObject exitDate;
    public GameObject taco;
    public GameObject datePj;
    public GameObject dateNoPj;
    public GameObject changeButtons;

    // Start is called before the first frame update
    void Start()
    {
        startButton = GameObject.Find("startText").GetComponent<TextMeshProUGUI>();
        PlayerPrefs.SetInt("TacoToggle", 0); // we are not in time taco so it doesn't exist
        if (PlayerPrefs.HasKey("DONE"))
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
        if (PlayerPrefs.HasKey("FinishGame?"))
        {
            startButton.text = "Start +";
        }
        else if (PlayerPrefs.HasKey("StopX"))
        {
            startButton.text = "Continue";
        }
        else
        {
            startButton.text = "Start";
        }
    }

    public void NoPJ()
    {
        datePj.SetActive(false);
        dateNoPj.SetActive(true);
    }

    public void PJ()
    {
        datePj.SetActive(true);
        dateNoPj.SetActive(false);
    }

    public void ExtraMenu()
    {
        if (menu.activeInHierarchy)
        {
            menu.SetActive(false);
            extra.SetActive(true);
        }
        else if (!menu.activeInHierarchy)
        {
            menu.SetActive(true);
            extra.SetActive(false);
        }
    }

    public void Date()
    {
        if (PlayerPrefs.HasKey("DONE"))
        {
            date.transform.localScale = new Vector3(1, 1, 1);
            date.transform.position = new Vector3(0, 0, 0);
            lockedDate.SetActive(false);
            changeButtons.SetActive(false);
            exitDate.SetActive(true);
            taco.SetActive(false);
        }
    }

    public void TimeTacos()
    {
        if (PlayerPrefs.HasKey("DONE"))
        {
            SceneManager.LoadScene("TimeTaco");
            PlayerPrefs.SetInt("TacoToggle", -1);
        }
        else if (PlayerPrefs.HasKey("FinishGame?"))
        {
            SceneManager.LoadScene("TimeTaco");
            PlayerPrefs.SetInt("TacoToggle", -1);
        }
        // use player prefs to check if we are entering time taco from the game or from the extras button
    }

    public void ExitDate()
    {
        date.transform.localScale = new Vector3(0.25f, 0.25f, 1);
        date.transform.position = new Vector3(4, 0, 0);
        exitDate.SetActive(false);
        taco.SetActive(true);
        changeButtons.SetActive(true);
    }
}
