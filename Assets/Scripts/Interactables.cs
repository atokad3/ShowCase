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
    private EnergyBar energyBar;
    private float maxEnergy;
    private float currentEnergy;

    private GameObject player;
    public GameObject box;
    public Sprite check;
    public Sprite bad;
    public GameObject closet;

    void Start()
    {
        energyBar = GameObject.Find("EnergyBar").GetComponent<EnergyBar>();
        taskIsDone = false;
        maxEnergy = PlayerPrefs.GetInt("MaxEnergy");
        currentEnergy = maxEnergy;
        player = GameObject.Find("Player");
        if(PlayerPrefs.HasKey("task" + taskNum))
        {
            LoadTask();
        }

    }

    void Update()
    {
        currentEnergy = energyBar.energySlider.value;
        if(Input.GetKeyDown(KeyCode.E) && glow.activeInHierarchy && !taskIsDone && energyCost <= currentEnergy)
        {
            if(tag != "Vacuum")
            { // if not vacuum then complete task & if also dresser change clothes
                DoTheTask();
            }
            else if(tag == "Vacuum" && closet.activeInHierarchy)
            { // if vacuum then closet has to be open to do task
                DoTheTask();
            }
        }
        else if(Input.GetKeyDown(KeyCode.E) && glow.activeInHierarchy && !taskIsDone && energyCost > currentEnergy)
        { // if you have less eneregy than what the task takes, cant do task
            glow.GetComponent<SpriteRenderer>().color = new Color(1, 0.5f, 0.5f, 1);
            StartCoroutine(NotEnoughOff());
        }
    }

    private void LoadTask()
    {
        //loads if task is done
        taskIsDone = true;
        box.GetComponent<SpriteRenderer>().sprite = check;
        if(name == "Dresser")
        {
            player.GetComponent<Animator>().SetBool("gotDressed", true);
        }
    }

    public void DoTheTask()
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

    public void DayChangeTask()
    {
        // resets task when day is over
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
        // makes tasks cost energy
        currentEnergy -= energyLoss;
        energyBar.SetEnergy(currentEnergy);
        PlayerPrefs.SetFloat("CurrentEnergy", currentEnergy);
    }

    IEnumerator NotEnoughOff()
    {
        yield return new WaitForSeconds(0.25f);
        glow.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
    }
}
