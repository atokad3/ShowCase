using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactables : MonoBehaviour
{

    public GameObject glow;
    public bool taskIsDone;
    public int taskNum;

    public int time;
    public int energyCost;
    public EnergyBar energyBar;
    public float maxEnergy = 100;
    public float currentEnergy;

    private GameObject player;
    public GameObject box;
    public Sprite check;
    public GameObject closet;

    // Start is called before the first frame update
    void Start()
    {
        taskIsDone = false;
        currentEnergy = maxEnergy;
        energyBar.SetMaxEnergy(maxEnergy);
        player = GameObject.Find("Player");
        if(PlayerPrefs.HasKey("task" + taskNum))
        {
            LoadTask();
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentEnergy = energyBar.energySlider.value;
        if(Input.GetKeyDown(KeyCode.E) && glow.activeInHierarchy && !taskIsDone)
        {
            if(tag != "Vacuum")
            {
                taskIsDone = true;
                glow.SetActive(false);
                LoseEnergy(energyCost);
                if (gameObject.name == "Dresser")
                {
                    player.GetComponent<Animator>().SetBool("gotDressed", true);
                }
                box.GetComponent<SpriteRenderer>().sprite = check;
                PlayerPrefs.SetString("task" + taskNum, "Done");
            }
            else if(tag == "Vacuum" && closet.activeInHierarchy)
            {
                taskIsDone = true;
                glow.SetActive(false);
                LoseEnergy(energyCost);
                box.GetComponent<SpriteRenderer>().sprite = check;
                PlayerPrefs.SetString("task" + taskNum, "Done");
            }
        }
    }

    private void LoadTask()
    {
        taskIsDone = true;
        box.GetComponent<SpriteRenderer>().sprite = check;
        if(name == "Dresser")
        {
            player.GetComponent<Animator>().SetBool("gotDressed", true);
        }
    }

    public void DayChangeTask()
    {
        PlayerPrefs.DeleteKey("task" + taskNum);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!taskIsDone)
        {
            glow.SetActive(true);
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        glow.SetActive(false);
    }

    private void LoseEnergy(int energyLoss)
    {
        currentEnergy -= energyLoss;
        energyBar.SetEnergy(currentEnergy);
    }
}
